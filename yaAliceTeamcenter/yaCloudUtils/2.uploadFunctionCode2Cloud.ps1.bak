if (Get-Command yc -errorAction SilentlyContinue)
{

$path2root = (get-item (Get-Item .).FullName).parent.FullName
$archive = 'dummyFunctionName.zip'
$path2archive = $path2root + "\" + $archive


Compress-Archive -Update -Path $path2root\*.cs,$path2root\*.csproj -DestinationPath $path2archive

yc serverless function version create --function-name=dummyFunctionName --runtime dotnetcore31 --entrypoint Main.Handler --memory dummyMemorym --execution-timeout dummyTimeOuts `
--service-account-id="dummyServiceAccountID" --source-path=$path2archive
}
else
{
    "Yandex Cloud CLI not installed"
    "Go to the follow link: https://cloud.yandex.com/en/docs/cli/quickstart"
}