
Complete the following files:
----------------------------------

# appsettings.json 
		> Replace "..." with your actual SQS url.

# QueueMessage.cs 
		> Add the correct properties of your queue message
		> Implement the Process() method.

# appsettings.development.json
		> If using localstack, provide the correct url. Otherwise remove this setting.
                See https://localstack.cloud/



=======================================================================================
=======================================================================================


Live AWS setup:
-----------------------------------

# Lambda role
		> Create a lambda role named "MY.PROJECT.NAME-runtime"
		> Add its ARN to aws-lambda-tools-defaults.json for "function-role"
		> Grant it access to the SQS queue:
		      {
                  "Version": "2012-10-17",
                  "Statement": [
                      {
                          "Effect": "Allow",
                          "Action": [ "sqs:ReceiveMessage", "sqs:DeleteMessage", "sqs:DeleteMessageBatch" ],
                          "Resource": "***** Your Queue ARN *****"
                      }
                  ]
              }

# Deployment bucket
        > Your entire solution needs an S3 bucket to upload the lambda onto.
        > Create it, and write its name in aws-lambda-tools-defaults.json for "s3-bucket"