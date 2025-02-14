### 2025.02.14 수업

* **Scene 등록 방법**
  * file → build profiles → SceneList에 씬을 등록

* 씬 로드 설정
  * single : 다른 씬으로 이동할 경우 기존 씬이 파괴됩니다.
  * additive : 게임 내에 씬이 동시에 켜지게 됩니다. ( 기존 씬에 새 씬이 들어오는 형태)
  * additive 주의 사항
    * Audio Listner 중복 조심
    * 카메라 기준으로 작업하는 코드를 짯을 때 기존의 설정으로 인해 동작이 제대로 안될 가능성이 있습니다.
    * Additive로 씬을 불러올 경우 - 기존의 씬이 Active Scene으로 유지되어 있음.

* 액티브 씬은 간단하게 오브젝트에 대한 생성 진행할 때 귀속되는 씬을 의미합니다.
  *  이 경우는 SceneManager의 SetActiveScene을 통해 설정을 변경해서 사용할 수 있습니다.
 
<hr/>

* 단축키
  * 컨트롤 a = 전체 선택
  * 컨트롤 k + f = 선택된 코드 들여쓰기 정렬
 
<hr/>

* **에셋 번들**
  * 에셋을 묶은 아카이브 파일을 의미합니다.
  * 에셋 : 유니티 내에서 쓸 수 있는 데이터 model, texture, audioclip ...

  * 에셋 번들을 사용하는 이유?
    * Application에 다운로드 진행을 편리하게 하기 위함
    * 에셋번들을 이용하면 런타임 환경에서 에셋을 불러서 사용할 수 있다.
    * ex) DLC 제공 / 컨텐츠 패치 / 모바일 게임 등에서 초기인스톨 사이즈 감소

  * 에셋 번들 등록 방법
    *  에셋을 클릭하면 아래쪽에 번들에 대한 정보가 나오게 되고 New 부분에 등록을 진행합니다.
  * 에셋 번들 빌드 방법
    * Assets 폴더에 Editor 폴더를 생성해 스크립트를 작성합니다.

<hr/>

* **어드레서블** - 하나의 보조도구
  * 패키지 →유니티 레지스트리 → addressable 다운 추가
  *  window → asset Management → group : 어드레서블에 대한 기본 설정을 진행할 수 있음
  * Remote : 서버
  * Local : 로컬
  * Default Local Group 클릭
  * Build & Load를 Remote로 변경

  * space is needed in cache 설정인 경우
    * 변경 사항이 있을 때 기존 버전을 유지하다가 공간이 부족한 경우에만 번들 삭제 후 새 번들을 다운로드

  * Cache Clear를 New Version Loaded로 설정
    * 변경 사항이 있을 경우 기존의 값을 삭제하고 새로운 값을 다운 받습니다.

  * Inspect Top Level Settings

  * 카탈로그의 build remote catalog 설정
    * 카탈로그 파일을 빌드하고 원격 서버에 업로드해서 실행중인 앱이 원격 서버에서 카탈로그를 불러올 수 있도록 하는 기능
    
