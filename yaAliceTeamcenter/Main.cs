using System;
using System.Net;
using System.Threading.Tasks;
using TCUtils;
using TestRestClientTC;
using yaAliceModelInOut;

namespace Main
{
    public class Handler
    {
        private static ExistPRs PRRsresults = new ExistPRs();
        private static TCSessionInfo TCSessionInfo = new TCSessionInfo();
        private static CookieContainer CookieID = new CookieContainer();
        private static DateTime convertedDate = new DateTime();
        private static int iCurrentPR, iCurrentPR4tSpeech;

        public async Task<AliceResponse> FunctionHandler(AliceRequest aliceRequest)
        {
            CookieID = (CookieContainer)await Helper.yaStorageDeserializingClass(Environment.GetEnvironmentVariable("yaAccessKeyId"), Environment.GetEnvironmentVariable("yaSecretAccessKey"), Environment.GetEnvironmentVariable("yaBucketName"), Environment.GetEnvironmentVariable("cookieFileName"));
            AliceResponse response;
            response = new AliceResponse();
            response.version = "1.0";
            response.response.text = "Этот навык позволяет взаимодействовать с системой Тимцентр. Если вы хотите узнать о нём больше, то скажите: Что ты умеешь?";
            response.response.tts = "Этот навык позволяет взаимодействовать с системой Тимцентр. Если вы хотите узнать о нём больше, то скажите: Что ты умеешь?";
            response.response.end_session = false;

            #region [alice bla-bla]

            //aliceIntAboutSkills - (что|чо|чё|шо) (ты) (умеешь|можешь|могёшь)
            if (aliceRequest?.request?.nlu?.intents?.aliceIntAboutSkills != null)
            {
                response.response.text = "Пока навык умеет находить зарегистрированные проблемы, что бы воспользоваться им, скажите: Найди Пи-ар";
                response.response.tts = "Пока навык умеет находить зарегистрированные проблемы, что бы воспользоваться им, скажите: Найди Пи-ар";
            }

            //aliceIntFindPR - (найди|найти|дай) (пиар|пиары|pr|пи-ар)
            if (aliceRequest?.request?.nlu?.intents?.aliceIntFindPR != null)
            {
                PRRsresults = await TeamcenterUtils.GetExistPRs(CookieID);
                iCurrentPR = 0;
                if (PRRsresults.TotalFound == 1)
                {
                    response.response.text = $"Найден: {PRRsresults.TotalFound} пиар. Рассказать про него?";
                    response.response.tts = $"Найден: {PRRsresults.TotalFound} пиар. Рассказать про него?";
                }
                else if (PRRsresults.TotalFound > 1)
                {
                    response.response.text = $"Найдено: {PRRsresults.TotalFound} пиара. Рассказать про них?";
                    response.response.tts = $"Найдено: {PRRsresults.TotalFound} пиара. Рассказать про них?";
                }
                else if (PRRsresults.TotalFound <= 0)
                {
                    response.response.text = "Пиаров нет, отличная работа!";
                    response.response.tts = "Пиаров нет, отличная работа!";
                    response.response.end_session = true;
                }

                response.response.end_session = false;
            }

            //aliceIntYesSpeakingAboutPRs - (расскажи|ага|давай|да|ещё|дальще|дальше|валяй|угу|ок|так)
            if (aliceRequest?.request?.nlu?.intents?.aliceIntYesSpeakingAboutPRs != null)
            {
                if (PRRsresults.TotalFound != 0)
                {
                    if (iCurrentPR < PRRsresults.TotalFound)
                    {
                        convertedDate = Helper.convertDateTime2Alice(PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.creation_date.uiValues[0].ToString());
                        iCurrentPR4tSpeech = iCurrentPR + 1;
                        //
                        response.response.text = $"Пиар: {iCurrentPR4tSpeech}, с обозначением: {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.item_id.dbValues[0].ToString()}" +
                        $" и именем {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_name.dbValues[0].ToString()}" +
                        $" был создан в {convertedDate.ToString("dd.MM.yyyy HH:mm")}, суть пиара:" +
                        $" {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_desc.dbValues[0].ToString()}" +
                        " Если хотите, что бы я повторила рассказ про этот Пиар, скажите: Повтори, а если вы хотите узнать про следующий Пиар, то скажите: Дальше";

                        response.response.tts = $"Пиар: {iCurrentPR4tSpeech}, с обозначением: {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.item_id.dbValues[0].ToString()}" +
                        $" и именем {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_name.dbValues[0].ToString()}" +
                        $" был создан в {convertedDate.ToString("dd.MM.yyyy HH:mm")}, суть пиара:" +
                        $" {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_desc.dbValues[0].ToString()}" +
                        " Если хотите, что бы я повторила рассказ про этот Пиар, скажите: Повтори, а если вы хотите узнать про следующий Пиар, то скажите: Дальше";

                        iCurrentPR++;
                        response.response.end_session = false;
                    }
                    else if (iCurrentPR == PRRsresults.TotalFound)
                    {
                        response.response.text = "Пиары кончились, ура!";
                        response.response.tts = "Пиары кончились, ура!";
                        iCurrentPR = 0;
                        response.response.end_session = true;
                    }
                }
                else
                {
                    response.response.text = "Запросите перечнь Пиаров, сказав: Найди пиары";
                    response.response.tts = "Запросите перечнь Пиаров, сказав: Найди пиары";
                    response.response.end_session = false;
                }
            }

            //aliceIntYesSpeakingAboutCurrentPR - (повтори)
            if (aliceRequest?.request?.nlu?.intents?.aliceIntYesSpeakingAboutCurrentPR != null)
            {
                if (PRRsresults.TotalFound != 0)
                {
                    if (iCurrentPR < PRRsresults.TotalFound)
                    {
                        iCurrentPR--;
                        convertedDate = Helper.convertDateTime2Alice(PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.creation_date.uiValues[0].ToString());
                        iCurrentPR4tSpeech = iCurrentPR + 1;
                        //
                        response.response.text = $"Пиар: {iCurrentPR4tSpeech}, с обозначением:{PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.item_id.dbValues[0].ToString()} " +
                        $" и именем {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_name.dbValues[0].ToString()} " +
                        $"был создан в {convertedDate.ToString("dd.MM.yyyy HH:mm")} , суть пиара: " +
                        $"{PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_desc.dbValues[0].ToString()} " +
                        "Если хотите, что бы я повторила рассказ про этот Пиар, скажите - Повтори, а если вы хотите узнать про следующий Пиар, то скажите - Дальше";

                        response.response.tts = $"Пиар: {iCurrentPR4tSpeech}, с обозначением:{PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.item_id.dbValues[0].ToString()} " +
                        $" и именем {PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_name.dbValues[0].ToString()} " +
                        $"был создан в {convertedDate.ToString("dd.MM.yyyy HH:mm")} , суть пиара: " +
                        $"{PRRsresults.ServiceData.ModelObjects[PRRsresults.ServiceData.Plain[iCurrentPR]].Props.object_desc.dbValues[0].ToString()} " +
                        "Если хотите, что бы я повторила рассказ про этот Пиар, скажите - Повтори, а если вы хотите узнать про следующий Пиар, то скажите - Дальше";

                        iCurrentPR++;
                        response.response.end_session = false;
                    }
                    else if (iCurrentPR == PRRsresults.TotalFound)
                    {
                        response.response.text = "Пиары кончились, ура!";
                        response.response.tts = "Пиары кончились, ура!";
                        response.response.end_session = true;
                    }
                }
            }

            //aliceIntCheckTCConnect - (как|чо там|как там) (Teamcenter|Тимцентр|Тим-центр)
            if (aliceRequest?.request?.nlu?.intents?.aliceIntCheckTCConnect != null)
            {
                TCSessionInfo = await TeamcenterUtils.GetInfoAboutTCSession(CookieID);
                iCurrentPR = 0;
                if (TCSessionInfo.serverVersion != null)
                {
                    response.response.text = $"Навык подключен к Тимцентр версии {TCSessionInfo.extraInfo.DisplayVersion.Substring(0, TCSessionInfo.extraInfo.DisplayVersion.IndexOf(':'))}, на сервере: {TCSessionInfo.extraInfo.hostName}";
                    response.response.tts = $"Навык подключен к Тимцентр версии {TCSessionInfo.extraInfo.DisplayVersion.Substring(0, TCSessionInfo.extraInfo.DisplayVersion.IndexOf(':'))}, на сервере: {TCSessionInfo.extraInfo.hostName}";
                }
                else
                {
                    response.response.text = "Навык не подключен к Тимцентр, что-то пошло не так, обратитесь к вашему АйТи";
                    response.response.tts = "Навык не подключен к Тимцентр , что-то пошло не так, обратитесь к вашему АйТи";
                    response.response.end_session = true;
                }
            }

            #endregion [alice bla-bla]

            return response;
        }
    }
}