* **스크립터블 오브젝트(SO)**
	* 유니티에서제공해주는 데이터 저장 객체
	* 게임 데이터를 관리하고, 여러 인스턴스에서 공유할 수 있도록 도와줍니다.

* 장점
	* 동일한 적(오브젝트)의 정보 등을 여러 오브젝트에서 공유해도 메모리는 한번만 차지합니다.
	* 데이터와 로직을 분리해서 사용할 수 있습니다.
	* ex) 캐릭터의 능력치 등을 SO로 관리할 경우 - 스탯에 대한 수정을 쉽게 진행할 수 있습니다.
	* 런타임 중에 데이터 수정이 가능합니다.
 * 단점
	* 복잡한 데이터 구조 등에서는 직렬화가 되지 않는 경우가 있어 데이터 손실 발생 위험이 있습니다.
	* 멀티 스레드 환경에서는 데이터 처리 시 충돌 문제가 우려될 수 있습니다.(이런 경우라면 데이터베이스 활용이 더 좋을 수 있습니다.)

* 사용 예시
	* 게임에 대한 기본 설정 값 (게임 난이도, 게임 사운드 설정, 컨트롤 설정)
	* 행동 패턴이나 능력치 등에 대한 설정
	* 별도의 데이터베이스를 따로 구현하지 않는다는 전제로 아이템 데이터베이스를 만들기 좋습니다.

<hr/>

* 유니티에서 특정 데이터 또는 기능을 구현하기 위해 적합한 자료형을 고르는건 필수입니다.
* 기본 자료형 이외에 특정 기능, 작업을 진행할 수 있는 데이터 집합체를 자료구조라고 부르겠습니다.(데이터 값의 모임)

* 자주 활용되는 자료구조
  * List : 순서대로 저장할 수 있고, 저장 데이터를 추가, 삭제, 검색할 수 있는 변경이 가능한 배열
  * Dictionary : 키 - 값으로 묶어서 저장할 수 있는 형태(json 파일에서도 확인 가능)
  * Queue : 자료를 선입선출(FIFO)로 관리할 때 사용할 자료 구조
  * Stack : 자료를 후입선출(LIFO)로 관리할 때 사용할 자료 구조
  * HashSet : 데이터의 중복을 전혀 허락하지 않는 경우, 정렬 순서가 필요 없는 경우

* Queue
  * 제공해주는 기능 : 삽입, 삭제, 첫번째 값 조회 기능
  * 단점 : 중간에 있는 데이터를 접근하는 부분에선 매우 비효율적입니다.

  * 큐를 이용해서 만들기 괜찮은 시스템

<hr/>

* 조건 Assets/Scripts/Dialog 폴더 위치에서 작업할 것

  * 대화 시스템
IEnumerator, StartCrorotine, Queue, List 등을 활용해 구현할 수 있습니다.

  * 만드는 방법
    * 대화에 대한 데이터 묶음을 따로 가지고 있습니다. (클래스 or 스크럽터블 오브젝트)

  * 대화를 시작할 경우
    * 큐에 해당 데이터들을 순서대로 Enqueue 합니다.

  * 버튼이나 키를 눌러 다음 대화로 이동하는 기능을 추가합니다.
    * 전달받은 큐를 Dequeue합니다.

  * 화면 상에 UI의 텍스트에 전달받은 값을 적용한다면 대화 기능처럼 보이게 될 것입니다.

  * 추가적으로 텍스트가 타이핑되는 효과(코루틴 설계)와 함께한다면 더 실감나는 기능을 구현해볼 수 있습니다.

  * 타이핑 텍스트?
    * 화면상에서 텍스트를 타이핑하듯이 출력하는 것을 의미합니다.

  * 만드는 방법
    * 문장 길이만큼 반복해서 UI 텍스트에 단어 하나하나를 +=로 추가합니다.
    * 1초나 0.1초 마다 한번씩 딜레이를 부여합니다.(코루틴)

