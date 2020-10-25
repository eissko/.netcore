- dotnet aws lambda template https://www.nuget.org/packages/Amazon.Lambda.Templates
  
### Install project template to dotnet
  ```
  dotnet new --install Amazon.Lambda.Templates::4.1.2
  ``` 

### Create new dotnet project of lambda template
- (https://docs.aws.amazon.com/lambda/latest/dg/csharp-package-cli.html)
  
```
dotnet new lambda.CustomRuntimeFunction --name MyLambda
```
### Install lambda dev tools
```
dotnet tool install --global Amazon.Lambda.Tools --version 4.3.0
```
### Build and Run project
```
dotnet run
```

### Add library/package from nuget.org
(https://www.nuget.org/packages/System.DirectoryServices/)

```
dotnet add package System.DirectoryServices --version 4.7.0
```

### Install dotnet core on linux (ubuntu 18.04)
- https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu
```
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```
- install sdk

```
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1
```

- self-contained application

```
dotnet publish --runtime ubuntu.18.04-x64 --self-contained true
```

- add nuget packate
```
dotnet add package System.Configuration.ConfigurationManager --version 5.0.0-rc.2.20475.5
```