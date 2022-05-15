namespace yaAliceTeamcenter
{

    public class Intents
    {
        public AliceIntAboutSkills aliceIntAboutSkills { get; set; }
        public AliceIntLoginTC aliceIntLoginTC { get; set; }
        public AliceIntFindPR aliceIntFindPR { get; set; }
        public AliceIntCheckTCConnect aliceIntCheckTCConnect { get; set; }
        public AliceIntYesSpeakingAboutPRs aliceIntYesSpeakingAboutPRs { get; set; }
        public AliceIntYesSpeakingAboutCurrentPR aliceIntYesSpeakingAboutCurrentPR { get; set; }
    }

    #region [Slots]
    public class AliceIntYesSpeakingAboutCurrentPR
    {
        public Slots slots { get; set; }
    }

    public class AliceIntYesSpeakingAboutPRs
    {
        public Slots slots { get; set; }
    }

    public class AliceIntAboutSkills
    {
        public Slots slots { get; set; }
    }

    public class AliceIntLoginTC
    {
        public Slots slots { get; set; }
    }

    public class AliceIntFindPR
    {
        public Slots slots { get; set; }
    }

    public class AliceIntCheckTCConnect
    {
        public Slots slots { get; set; }
    }

    public class Slots
    {
    }

    #endregion [Slots]
}