if (Get-Command yc -errorAction SilentlyContinue)
{
    _yc serverless function create --name=teamcenter-alice --async
    _yc serverless function get --name=teamcenter-alice
}
else
{
    "Yandex Cloud CLI not installed"
    "Go to the follow link: https://cloud.yandex.com/en/docs/cli/quickstart"
}