<!-- ABOUT THE PROJECT -->
## About This Project

We can run this application to test the server and application will run TLS against endpoints that will only accept certain TLS versions.

## Other considerations
These websites will not validate the TLS Ciphers so if you experience issues you can run the display Ciphers option on windows and display and compare your Ciphers against those that would be required for that verion. If you are missing required ciphers consider performing a windows update.

https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-security-policy-table.html