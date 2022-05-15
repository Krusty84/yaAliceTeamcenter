﻿if (Get-Command yc -errorAction SilentlyContinue)
{
    yc serverless function logs -f --name=teamcenter-alice
}
else
{
    "Yandex Cloud CLI not installed"
    "Go to the follow link: https://cloud.yandex.com/en/docs/cli/quickstart"
}