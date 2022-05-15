if (Get-Command yc -errorAction SilentlyContinue)
{

$path2root = (get-item (Get-Item .).FullName).parent.FullName
$archive = 'teamcenter-alice.zip'
$path2archive = $path2root + "\" + $archive


Compress-Archive -Update -Path $path2root\*.cs,$path2root\*.csproj -DestinationPath $path2archive

yc serverless function version create --function-name=teamcenter-alice --runtime dotnetcore31 --entrypoint Main.Handler --memory 128m --execution-timeout 10s `
--service-account-id="ajev4i09fcbm0votn8f1" --environment=tcURL="https://1d45-46-242-15-94.eu.ngrok.io",yaAccessKeyId="YCAJE2xn7sVRnX2GitPwi1tEc",userPassword="user4",userName="user4",yaBucketName="temp-file-storage",cookieFileName="tc_cookie",yaSecretAccessKey="YCPpqNpSsaur5rHV2UhwUeQ7UU0CZGBQAgzrB6Ju" --source-path=$path2archive
}
else
{
    "Yandex Cloud CLI not installed"
    "Go to the follow link: https://cloud.yandex.com/en/docs/cli/quickstart"
}