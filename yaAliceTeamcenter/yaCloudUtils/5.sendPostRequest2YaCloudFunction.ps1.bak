$payload = @{}
$temp1=yc serverless function get --name=dummyFunctionName | Select-String -pattern "http_invoke_url:"
$yaCloudFunctionURL=($temp1 -split ': ')[1] | Out-String

Invoke-WebRequest -Uri $yaCloudFunctionURL -Method POST -Body $payload