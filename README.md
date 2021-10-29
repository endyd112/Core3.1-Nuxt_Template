# Core3.1-Nuxt_Template

# 개요
백엔드 API 서버와 프론트엔드  Nuxt Framework 를 사용한 웹앱 템플릿

# 구성환경
IDE : VS2019 및 VSCODE
Node Package Manager : latest
SDK : .Net Core 3.1.0 - 64x
JS Frameworkd : Nuxt js 3.7.0
Canvas2D Lib : Konva latest

# 사용법

1. 명령어 프롬프트에서 프로젝트 경로 내 ClientApp 으로 이동 후 명령어 입력 "npm i" 
2. "npm run build" 
3. "npm run generate"
4. VS2019 에서 프로젝트 로드 후 dotNet Core로 실행
5. localhost:8080 접속


![20211027_090450](https://user-images.githubusercontent.com/26294051/138978071-a673539b-836e-4ce4-a0cc-a29fb45d62a0.png)


# 공유 메모리 접근

    using VueJSDotnet51_Demo.Helper.*
    using VueJSDotnet51_Demo.Structure.*

    1. Get Handle 

    var hBASIC_CFG = SharedMem.GetMappedFileHandle("MEM_BASIC");

    2. Mashalling

    var tmp = (BASIC_CFG)Marshal.PtrToStructure(hBASIC_CFG, typeof(BASIC_CFG));