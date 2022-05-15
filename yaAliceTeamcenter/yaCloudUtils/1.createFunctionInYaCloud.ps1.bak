if (Get-Command yc -errorAction SilentlyContinue)
{
    yc serverless function create --name=dummyFunctionName --async
    yc serverless function get --name=dummyFunctionName
}
else
{
    "Yandex Cloud CLI not installed"
    "Go to the follow link: https://cloud.yandex.com/en/docs/cli/quickstart"
}