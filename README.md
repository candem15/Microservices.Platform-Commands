# 
<h2 align="center">Microservices.Platform-Commands</h2>
<h4 align="center">Microservices architecture fundemantals with two seperate rest api</h2>

<details>
  <summary>Table of Contents</summary>
  
  1. <a href="#About Project">About Project</a>
      * <a href="#Built With">Built With</a>
  2. <a href="#Architectures of Project">Architectures of Project</a>
     * <a href="#Platform Service Architecture">Platform Service Architecture</a>
     * <a href="#Commands Service Architecture">Commands Service Architecture</a>
     * <a href="#Kubernetes Architecture">Kubernetes Architecture</a>
  3. <a href="#Postman Test Outputs and Kubernetes on Docker">Postman Test Outputs and Kubernetes on Docker</a>
     * <a href="#Kubernetes on Docker">Kubernetes on Docker</a>
     * <a href="#Get All Platforms on PlatformService">Get All Platforms on PlatformService</a>
     * <a href="#Create Platform on PlatformService">Create Platform on PlatformService</a>
     * <a href="#Get All Platforms on CommandsService">Get All Platforms on CommandsService</a>
  4. <a href="#Contact">Contact</a>
  
</details>

# <p id="About Project">About Project</p>

We have two REST API that is called PlaformService and CommandsService. On our PlatformService we can do all CRUD operations about "Platform" that contains bunch of properties(id, name, publisher...). On the other hand at CommandsService, we have "Commands" that related to "Platform" at PlatformService. One platform object can have multiple commands not vice versa. These REST API's can be functional with their own even they are related to each other. For making this possible we used microservices architecture.

## <p id="Built With">Built With</p>
<div>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width=75px>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-plain.svg" width=75px>
<img src="https://raw.githubusercontent.com/devicons/devicon/2ae2a900d2f041da66e950e4d48052658d850630/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" width=75px>
<img src="https://raw.githubusercontent.com/devicons/devicon/2ae2a900d2f041da66e950e4d48052658d850630/icons/kubernetes/kubernetes-plain-wordmark.svg" width=75px>
<img src="https://svgseek.com/img/svg/rabbitmq-104937.svg" width=75px>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/docker/docker-original-wordmark.svg" width=75px>
</div>
     
# <p id="Architectures of Project">Architectures of Project</p>

## <p id="Solution Architecture">Solution Architecture</p>
<img src="https://i.imgur.com/DCzyFMl.png" alt="png">

## <p id="Platform Service Architecture">Platform Service Architecture</p>
<img src="https://i.imgur.com/4YB45bM.png" alt="png">

## <p id="Commands Service Architecture">Commands Service Architecture</p>
<img src="https://i.imgur.com/7j7IsWn.png" alt="png">

## <p id="Kubernetes Architecture">Kubernetes Architecture</p>
<img src="https://i.imgur.com/giiKkOn.png" alt="png">

# <p id="Postman Test Outputs and Kubernetes on Docker">Postman Test Outputs and Kubernetes on Docker</p>

## <p id="Kubernetes on Docker">Kubernetes on Docker</p>
<img src="https://i.imgur.com/2BgVTJS.png" alt="png">

## <p id="Get All Platforms on PlatformService">Get All Platforms on PlatformService</p>
<img src="https://i.imgur.com/qFAkLtj.png" alt="png">

## <p id="Create Platform on PlatformService">Create Platform on PlatformService</p>
<img src="https://i.imgur.com/QOYXgur.png" alt="png">

## <p id="Get All Platforms on CommandsService">Get All Platforms on CommandsService</p>
<img src="https://i.imgur.com/JFYFdON.png" alt="png">

Here with our GET request CommandsService is synchronizing(with Platform Published Event) all existing platforms on PlatformService with its own database. At following screenshot we can see how the flow works on Kubernetes.

<img src="https://i.imgur.com/d9SyAP8.png" alt="png">

# <p id="Contact">Contact</p>

<div>
<a href="https://www.linkedin.com/in/eray-berbero%C4%9Flu"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original-wordmark.svg" alt="LinkedIn" width="75"/></a>
<a href="https://github.com/candem15"><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original-wordmark.svg" alt="Github" width="75"/></a>
<a href="mailto:eraybrbr@gmail.com"><img src="https://storage.googleapis.com/gweb-uniblog-publish-prod/images/Gmail.max-1100x1100.png" alt="Gmail" width="75"/></a>
</div>
