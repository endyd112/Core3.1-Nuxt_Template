using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace VueJSDotnet51_Demo.Structure
{

    public enum CFG_CNT
    {
        /// <summary>
        /// HMI
        /// </summary>
        CC_HMI = 0,

        /// <summary>
        /// IED
        /// </summary>
        CC_IED,

        /// <summary>
        /// SWITCH
        /// </summary>
        CC_SWITCH
    };

    public enum _PROC_INFO
    {
        /// <summary>
        /// SNTP & RESET
        /// </summary>
        SNTP = 0,

        /// <summary>
        /// 61850 서버
        /// </summary>
        IEC61850,

        /// <summary>
        /// 패킷 저장
        /// </summary>
        PKT_SAVE,

        /// <summary>
        /// MMS 감시&처리
        /// </summary>
        MMS_MON,

        /// <summary>
        /// GOOSE 감시& 처리
        /// </summary>
        GOOSE_MON,

        /// <summary>
        /// SNMP 감시 처리
        /// </summary>
        SNMP_MON,

        /// <summary>
        /// SCL 읽기/비교, IET 읽기/비교
        /// </summary>
        SCL_PROC,

        /// <summary>
        /// 이력 처리	//EventProc
        /// </summary>
        RPT_OUT,

        /// <summary>
        /// FilteringProc
        /// </summary>
        FILTER_MNG
    }

    public enum REQ_CODE
    {
        RESET = 1,      //재시작
        DEV_STOP,       //정지
        DEV_RUN,        //기동

        PACKET_SAVE,    //패킷 저장

        //추가
        READ_MMS_LOG,
        READ_GOOSE_LOG,
        READ_GOOSE_SCAN,
        READ_SNMP_LOG,
        READ_PROC_LOG,

        IED_ADD,        //IED 등록 
        IED_MOD,        //IED 수정
        IED_DEL,        //IED 삭제
        HMI_ADD,        //상위 장치 추가
        HMI_MOD,        //상위 장치 수정
        HMI_DEL,        //상위 장치 삭제
        IET_CMP,        //IET 파일 비교
        IET_DOWNLOAD,   //IET 파일 다운로드
        CID_DOWNLOAD,   //CID 파일 다운로드
        SCL_CMP,        //SCL 파일 비교
        BASE_MNG,       //기본 설정 편집

        RPTSET_ADD,     //장치운영 기준 등록
        RPTSET_MOD,     //장치운영 기준 수정
        RPTSET_DEL,     //장치운영 기준 삭제

        CHECK_REPORT,   //실시간 리포트 적합성 검사
        CHECK_GOOSE,    //GOOSE 미송신 검출 기준 변경
        SCAN_GOOOSE,    //모든 GOOSE 메세지 결과 뷰어



        BASE_MNG_SNTP,      //SNTP 설정 편집
        BASE_MNG_SYSTEM,      //SYSTEM 설정 편집
        BASE_MNG_STANDARD,      //STANDARD 설정 편집
        BASE_MNG_USER,      //USER 설정 편집
        BASE_MNG_NETWORK,      //NETWORK 설정 편집
        BASE_MNG_LOGOUT,

        SWITCH_ADD,          //스위치 추가
        SWITCH_MOD,          //스위치 수정
        SWITCH_DEL,          //스위치 삭제

        NIC_REFRESH,            //NIC 갱신
        MEMORY_RESET,           //실시간 갱신값 리셋
        PACKET_INUSE,           //패킷처리제외 저장

        GOOSE_MAXSET
    }

    public enum RES_RESULT
    {
        RES_OK = 1,         //정상
        RES_ERR,            //이상
        RES_CIDERR,         //CID 이상
        RES_CMPERR,         //IP 중복
        RES_MISSING			//IP 누락
    }


    /// <summary>
    /// ver 160512
    /// 
    /// [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    /// Pack = 1 << 사용안함
    /// </summary>
    public class SMD_Struct
    {
        #region CONST

        /// <summary>
        /// HMI 개수
        /// </summary>
        public const ushort HMI_CNT = 16;

        /// <summary>
        /// SWITCH 개수
        /// </summary>
        public const ushort SWITCH_CNT = 32;

        /// <summary>
        /// IED 개수
        /// </summary>
        public const ushort IED_CNT = 128;

        /// <summary>
        /// NETWORK 장치 개수
        /// </summary>
        public const ushort NETWORK_CNT = 8;

        /// <summary>
        /// USER 개수
        /// </summary>
        public const ushort USER_CNT = 16;

        /// <summary>
        /// 시스템 전체 장치 개수
        /// </summary>
        public const ushort DEVICE_CNT = HMI_CNT + SWITCH_CNT + IED_CNT;

        /// <summary>
        /// CB 개수
        /// </summary>
        public const ushort CB_CNT = 256;

        /// <summary>
        /// PORT 개수
        /// </summary>
        public const ushort PORT_CNT = 32;

        /// <summary>
        /// EVENT 개수	190329 100->1000 변경
        /// </summary>
        public const ushort EVT_CNT = 1000;

        /// <summary>
        /// 모듈 개수
        /// </summary>
        public const ushort PROC_CNT = 16;

        /// <summary>
        /// 문자열 길이
        /// </summary>
        public const ushort SIZE_STRING = 256;

        /// <summary>
        /// IP 길이
        /// </summary>
        public const ushort SIZE_IP = 18;

        /// <summary>
        /// MAC 길이
        /// </summary>
        public const ushort SIZE_MAC = 32;

        /// <summary>
        /// Option field 길이
        /// </summary>
        public const ushort SIZE_RCB_OP = 4;

        /// <summary>
        /// trigger option 길이
        /// </summary>
        public const ushort SIZE_RCB_TG = 2;

        public const ushort MAX_EVT_COUNT = 999;
        public const ushort MAXPACKETLEN = 999;


        #endregion

        #region IED INFO

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _REPORT_CB
        {
            /// <summary>
            /// RCB 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RCB_NAME;

            /// <summary>
            /// 리포트 아이디
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string REPORT_ID;

            /// <summary>
            /// 버퍼 타임
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int BUFFER_TIME;

            /// <summary>
            /// 버퍼드
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int BUFFERED;

            /// <summary>
            /// 전송 주기
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int INTEGRITY_PERIOD;

            /// <summary>
            /// DataChange(0), QualityChange(1), DataUpdate(2), Intergrity(3), GI(4)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 5)]
            public int[] TRIGGER_OPTION;

            /// <summary>
            /// Sequence(0), Timestamp(1), ReasonCode(2), Dataset(3), Datareference(4), BufferOverflow(5), EntryID(BUF), ConfigRevision(7)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 8)]
            public int[] OPTION_FIELD;

            /// <summary>
            /// 웹 뷰어용	//DataChange(0), QualityChange(1), DataUpdate(2), Intergrity(3), GI(4)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string TRIGGER_OPTION_DISP;

            /// <summary>
            /// 웹 뷰어용 //Sequence(0), Timestamp(1), ReasonCode(2), Dataset(3),Datareference(4), BufferOverflow(5), EntryID(BUF), ConfigRevision(7)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string OPTION_FIELD_DISP;

            /// <summary>
            /// 데이터 셋
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATASET_NAME;

            /// <summary>
            /// 상위 DEST IP 180409 HK 추가
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string DEST_IP;

            /// <summary>
            /// 상위 DEVICE NAME	180418 HK 추가
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DEST_DEVICE_NAME;

            /// <summary>
            /// 리포트 매핑 인덱스 180419 HK 추가 0:HMI 1: GW1 2: GW2
            /// </summary>
            byte RPT_INDEX;

            /// <summary>
            /// 정상(0), 이상(1)  : 실시간 갱신 리포트 상태 화면에서 갱신용으로 사용
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RPT_STATUS;

            /// <summary>
            /// 미송신 상태 확인
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RPT_ERR_STS;

            /// <summary>
            /// 미송신 누적 횟수  : 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RPT_CNT_ERR;

            /// <summary>
            /// 총 전송 횟수      : 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RPT_CNT_TOT;

            /// <summary>
            /// 이벤트 전송 횟수  : 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RPT_CNT_EVT;

            /// <summary>
            /// 최종 수신 시간	: 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long RPT_TIME;

            /// <summary>
            /// 최종 수신 시간	: 실시간 갱신(웹용)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string RPT_TIMESTAMP;

            /// <summary>
            /// 최대 전송 주기	: 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RPT_GAP_MAX;

            /// <summary>
            /// 최소 전송 주기	: 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RPT_GAP_MIN;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _GOOSE_CB
        {
            /// <summary>
            /// GOOSE CB 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GOCB_NAME;

            /// <summary>
            /// GOOSE ID
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GO_ID;

            /// <summary>
            /// 데이터 셋
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATASET_NAME;

            /// <summary>
            /// MAC 어드레스
            /// </summary>
            //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = 6)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;

            /// <summary>
            /// MAC 어드레스(WEB 표시용)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_MAC)]
            public string MAC_ADDR;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SRC_MAC;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_MAC)]
            public string SRC_MAC_ADDR;

            [MarshalAs(UnmanagedType.I4)]
            public int APP_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int CONFREV;

            [MarshalAs(UnmanagedType.I4)]
            public int MAX;


            /// <summary>
            /// 마지막 순서 넘버
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_SEQ_NO;

            /// <summary>
            /// 상태 번호(ST NUM)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_STS_NO;

            /// <summary>
            /// 전송간격(TAL)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_TAL;

            /// <summary>
            /// 정상(0), 이상(1) : 실시간 갱신. GOOSE 상태 화면에서 갱신용으로 사용.
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_STATUS;

            /// <summary>
            /// goose 미송신 발생 확인
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_ERR_STS;

            /// <summary>
            /// 미송신 누적 횟수 : 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_CNT_ERR;

            /// <summary>
            /// 최종 수신 시간	: 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long GSE_TIME;

            /// <summary>
            /// 최종 수신 시간	: 실시간 갱신(웹용)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string GSE_TIMESTAMP;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _DA_ITEM
        {
            /// <summary>
            /// DA ITEM 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string ITEM_NAME;

            /// <summary>
            /// DA ITEM 데이터 타입
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int ITEM_TYPE;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _DATASET
        {
            /// <summary>
            /// 데이터 셋 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATASET_NAME;

            /// <summary>
            /// DA ITEM 개수(최대 100)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int DA_ITEM_COUNT;

            /// <summary>
            /// DA ITEM 정보
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = IED_CNT)]
            public _DA_ITEM[] DA_ITEM_INFO;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _IED
        {
            /// <summary>
            /// 감시 정지(0), 재개(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RUN_STOP_MMS;

            [MarshalAs(UnmanagedType.I4)]
            public int RUN_STOP_GOOSE;

            /// <summary>
            /// IED 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string IED_NAME;

            /// <summary>
            /// IED IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP;

            /// <summary>
            /// CID 파일 저장 경로
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string CID_FILE;

            /// <summary>
            /// IET 파일 저장 경로
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string IET_FILE;

            /// <summary>
            /// MAC 어드레스
            /// </summary>
            //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = 6)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;

            /// <summary>
            /// MAC 어드레스(WEB 표시용)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_MAC)]
            public string MAC_ADDR;

            /// <summary>
            /// RCB 개수
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RCB_COUNT;

            /// <summary>
            /// GOOSE CB 개수
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GOCB_COUNT;

            /// <summary>
            /// 데이터 셋 개수
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int DATASET_COUNT;

            /// <summary>
            /// RCB 정보
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CB_CNT)]
            public _REPORT_CB[] REPORT_CB_INFO;

            /// <summary>
            /// GOOSE 정보
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CB_CNT)]
            public _GOOSE_CB[] GOOSE_CB_INFO;

            /// <summary>
            /// 데이터셋 정보
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CB_CNT)]
            public _DATASET[] DATASET_INFO;


            /// <summary>
            /// 상위 연결 상태  0: 중지 1: 정상 2: 이상 3: 리포트 이상 4 : 서버이상 5: 클라이언트 이상
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = HMI_CNT)]
            public int[] MMS_STATUS;

            /// <summary>
            /// GOOSE 상태	0: 이상	1: 정상
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_STATUS;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct IED_INFO
        {
            /// <summary>
            /// 접근 플래그 0,1,2 = 업데이트 안됨
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = IED_CNT)]
            public _IED[] IED_ITEM;

        }

        #endregion

        #region HMI INFO

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct _HMI
        {
            /// <summary>
            /// 감시 정지(0), 재개(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RUN_STOP;

            /// <summary>
            /// 상위 장치 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string HMI_NAME;

            /// <summary>
            /// 상위 장치 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string HMI_IP;

            /// <summary>
            /// 연결 상태, 단절(0), 연결(1) : 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int HMI_NETSTATUS;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HMI_INFO
        {
            /// <summary>
            /// 접근 플래그 0,1,2 = 업데이트 안됨
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _HMI[] HMI_ITEM;
        }

        #endregion

        #region BASIC CONFIG

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_COUNT
        {
            /// <summary>
            /// 스위치에 붙는 장비 구분(0:HMI, 1:IED, 2:SNTP, 3:SWITCH, ...)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 10)]
            public int[] DEVICE_COUNT;

            /// <summary>
            /// 리포트 기준 설정치 개수(최대 128) : 등록된 운영기준
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int REPORT_CFG_COUNT;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_61850
        {
            /// <summary>
            /// 네트워크 연결상태,	정상(0), 이상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STS_NMS;

            /// <summary>
            /// 주요기능상태,	정상(0), 이상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STS_FUCTION;

            /// <summary>
            /// MMS 통신 상태,	정상(0), 이상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STS_MMS_TRS;

            /// <summary>
            /// REPORT 미송신 상태,	정상(0), 이상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STS_REPORT_ERR;

            /// <summary>
            /// GOOSE 미송신 상태,	정상(0), 이상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STS_GOOSE_ERR;

            /// <summary>
            /// 미등록 GOOSE 검출, 정상(0), 이상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STS_GOOSE_MIS;

            /// <summary>
            /// SNTP 이상 검출, 정상(0), 이상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STS_SNTP_ERR;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_MANAGE
        {
            /// <summary>
            /// IED 추가, 기본(0), 추가(1), 삭제(2) 읽으면 0으로 초기화
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int IED_MODIFY;

            /// <summary>
            /// 추가/삭제할 IED IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string MOD_IED_IP;

            /// <summary>
            /// 등록할 운영기준 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string CFG_RPTSET_NAME;

            /// <summary>
            /// 버퍼 타임
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_BUFFER_TIME;

            /// <summary>
            /// 버퍼드
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_BUFFERED;

            /// <summary>
            /// 전송 주기
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_INTEGRITY_PERIOD;

            /// <summary>
            /// DataChange(0), QualityChange(1), DataUpdate(2), Intergrity(3), GI(4)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 5)]
            public int[] CFG_TRIGGER_OPTION;

            /// <summary>
            /// Sequence(0), Timestamp(1), ReasonCode(2), Dataset(3)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 8)]
            public int[] CFG_OPTION_FIELD;

            /// <summary>
            /// 리포트 기준 설정치 개수(최대 128) : 등록된 운영기준
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int REPORT_CFG_COUNT;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_SNTP
        {
            /// <summary>
            /// SNTP 서버 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string SNTP_IP;

            /// <summary>
            /// SNTP 동기화 주기(초)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SNTP_TIMER;

            /// <summary>
            /// SNTP 동기화 시간
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
            public string SNTP_SYNC_TIME;

            /// <summary>
            /// SNTP 동기화 실패 코드 : 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SNTP_SYNC_FAIL;

            /// <summary>
            /// SNTP 동기화 사용 여부, 미사용(0), 사용(1) : 예비
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SNTP_SYNC_YN;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_SYSTEM
        {
            /// <summary>
            /// 장치 리셋 : 대기(0), 리셋(1), 셧다운(2)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int DEV_RESET;

            /// <summary>
            /// 최종 리셋 시간 : 실시간 갱신
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
            public string RESET_TIME;

            /// <summary>
            ///  0 : C 드라이브 총 용량(GB) 1: D 드라이브 2: E드라이브
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R8, SizeConst = 3)]
            public double[] TOTAL_SPACE;

            /// <summary>
            /// C 드라이브 사용 가능 용량(GB)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R8, SizeConst = 3)]
            public double[] FREE_SPACE;

            /// <summary>
            /// C 드아이브 사용 량(GB)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R8, SizeConst = 3)]
            public double[] USAGE_SPACE;

            /// <summary>
            /// 드라이브 용량 감시 비율(설정 비율 보다 남은 비율이 낮아지면 자동 삭제)
            /// </summary>
            [MarshalAs(UnmanagedType.R8)]
            public double DEL_SPACE_RATIO;

            /// <summary>
            /// 파일 자동 삭제 감시 주기(해당 주기마다 드라이브 용량 체크해서 실행)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int DEL_SPACE_TIMER;

            /// <summary>
            /// CPU 점유율
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CPU_SHARE;

            [MarshalAs(UnmanagedType.I4)]
            public int CPU_MAX;

            /// <summary>
            /// Memory
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int MEMORY_SHARE;

            [MarshalAs(UnmanagedType.I4)]
            public int MEMORY_MAX;

            /// <summary>
            /// 네트워크 NIC설정에서 사용으로 설정한 네트워크 카드에 대한 트래픽 정보
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int NETWORK_SHARE;

            [MarshalAs(UnmanagedType.I4)]
            public int NETWORK_MAX;


        }

        /// <summary>
        /// 운영기준 관련, 검출 기준
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_OPER_STANDARD
        {
            /// <summary>
            /// 사용할 기준 설정 정보 위치, REPORT_CFG_INFO 참고
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_REPORT_INDEX;

            /// <summary>
            /// GOOSE 미송신 검출 기준(초) (goose)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CHECK_TIME_GOOSE;

            /// <summary>
            /// 미송신 검출 기준(초) (report)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CHECK_TIME;

            /// <summary>
            /// GOOSE MAX 기본 값
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GOOSE_MAX_DEFAULT;

            /// <summary>
            /// 리포트 시간이 SNTP 동기가 안된 경우에 허용 범위(초)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CHECK_SNTP_GAP;

            /// <summary>
            /// GOOSE SCAN 시간 설정
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GOOSE_SCAN_TIME;

            /// <summary>
            /// 실시간 Report 검사 최대 시간설정
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int REPORT_SCAN_TIME;

            /// <summary>
            /// 리포트 시간이상 검출(시)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int TIME_OFFSET;

            /// <summary>
            /// 자동 로그아웃 주기
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int LOG_OUT_TIMER;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct USER_INFO
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string USER;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string PWD;
            [MarshalAs(UnmanagedType.I4)]
            public int LEVEL;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_OPER_USER
        {
            public USER_INFO userInfo;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG_NETWORK
        {
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.I4)]
            public int ENABLE;

            /// <summary>
            /// 2차원 배열 8 * 64
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = 512)]
            public char[] NAME;

            /// <summary>
            /// 2차원 배열 8 * 16
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = 144)]
            public char[] IP;

            /// <summary>
            /// 2차원 배열 8 * 64
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = 512)]
            public char[] DESC;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct BASIC_CFG
        {
            public BASIC_CFG_COUNT CFG_COUNT;
            public BASIC_CFG_61850 CFG_61850;
            public BASIC_CFG_MANAGE CFG_MANAGE;
            public BASIC_CFG_SNTP CFG_SNTP;
            public BASIC_CFG_SYSTEM CFG_SYSTEM;
            public BASIC_CFG_OPER_STANDARD CFG_OPER_STANDARD;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = USER_CNT)]
            public BASIC_CFG_OPER_USER[] CFG_OPER_USER;

            public BASIC_CFG_NETWORK CFG_NETWORK;
        }

        #endregion

        #region SWITCH INFO

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _SWITCH
        {
            /// <summary>
            /// 스위치 최초 상태 판단플래그. Enable된 IED들 중에서 최초 리포트 값을 받으면 통신이 된 것으로 판단하고 스위치 포트 상태를 1로 변경한다.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = PORT_CNT)]
            public int[] SWITCH_INIT_FLAG;

            /// <summary>
            /// 스위치 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string SWITCH_NAME;

            /// <summary>
            /// 스위치 OID or MAC Address 스위치를 구별할 수 있는 정보를 선택
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string SWITCH_IP;

            /// <summary>
            /// 스위치 시작 포트 번호
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SWITCH_SEQ;

            /// <summary>
            /// 스위치 포트 개수
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SWITCH_PORT_COUNT;

            /// <summary>
            /// 스위치 포트 상태, 	 이상(0), 정상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = PORT_CNT)]
            public int[] SWITCH_PORT_STATUS;

            /// <summary>
            /// 스위치 상태            이상(0), 정상(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SWITCH_STATUS;

            /// <summary>
            /// 스위치 포트에 할당된 장비의 IP, SizeConst = (PORT_CNT * SIZE_IP)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = (PORT_CNT * SIZE_IP))]
            public char[] SWITCH_PORT_DEV_IP;

            /// <summary>
            /// SizeConst = (PORT_CNT * 256)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = (PORT_CNT * 256))]
            public char[] SWITCH_DEVICE_NAME;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SWITCH_INFO
        {
            /// <summary>
            /// 접근 플래그 0,1,2 = 업데이트 안됨
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SWITCH_CNT)]
            public _SWITCH[] SWITCH_ITEM;
        }

        #endregion

        #region REQUEST INFO

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct _REQ_AREA
        {
            /// <summary>
            /// 요청 구분, enum REQ_CODE
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int REQ_CODE1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string REQ_BUF_1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string REQ_BUF_2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string REQ_BUF_3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string REQ_BUF_4;

            /// <summary>
            /// 1:요청, 0:미요청 (0:MMS, 1:REPORT, 2:GOOSE, 3:SNMP 상태, 4:HMI 연결이상, 5, IED 연결이상)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 8)]
            public int[] REQ_EVENT;

            /// <summary>
            /// PACKET_MODE = 0 인 경우만 체크
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int REQ_IEDCNT;

            /// <summary>
            /// PACKET_MODE = 0 인 경우만 체크
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStr, SizeConst = (DEVICE_CNT * SIZE_IP))]
            public char[] REQ_IP;

            /// <summary>
            /// 범위 시작 시간
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
            public string TIME_START;

            /// <summary>
            /// 범위 끝 시간
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
            public string TIME_END;

            /// <summary>
            /// 저장 여부, 검색(0), 저장(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SAVE_YN;

            /// <summary>
            /// 요청여부,  기본(0), 요청(1), 읽으면 0으로 초기화
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int ISACK;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct _RES_AREA
        {
            /// <summary>
            /// 응답 구분, enum REQ_CODE
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RES_CODE1;

            /// <summary>
            /// 요청 결과, enum RES_RESULT 정상(1), 파일로` 응답하는 경우는 무조건 정상(1)로 세팅하고, 파일로 저장한다.
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int RES_RESULT1;

            /// <summary>
            /// 결과 파일명, 운영기준 일때 운영기준 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RES_BUF;

            /// <summary>
            /// 운영기준 검사 결과
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 16)]
            public int[] RES_CMP;

            /// <summary>
            /// 메세지 - 운영기준 일때 정상/이상
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RES_MSG;

            /// <summary>
            /// 요청여부,  기본(0), ]응답(1)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int ISACK;

        }


        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct REQUEST_INFO
        {
            public _REQ_AREA REQ_AREA;
            public _RES_AREA RES_AREA;
        }

        #endregion

        #region SHM_MMS

        /// <summary>
        /// MMS 서비스 이력
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _MMS_LOG
        {
            /// <summary>
            /// 시간
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long TIME;

            /// <summary>
            /// 송신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_S;

            /// <summary>
            /// 수신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_E;

            /// <summary>
            /// 0: 접속 1: 단절 2: 리포트 3: 제어 4: 제어 외 write
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int SERVICE;

            /// <summary>
            /// enum MMS_STATUS
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            /// <summary>
            /// 리포트인 경우 삽입, 아니면 NULL
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RCB_NAME;

            /// <summary>
            /// 리포트 타임스탬프
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long TIMESTAMP;

            /// <summary>
            /// 버퍼 타임
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int BUFFER_TIME;

            /// <summary>
            /// 버퍼드
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int BUFFERED;

            /// <summary>
            /// 전송 주기
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int INTEGRITY_PERIOD;

            /// <summary>
            /// packet manager에서 자료형 확인 (byte인지, short 인지?)
            /// </summary>
            [MarshalAs(UnmanagedType.I2)]
            public short TRIGGER_OPTION;

            [MarshalAs(UnmanagedType.I2)]
            public short OPTION_FIELD;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_MMS_LOG
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool FLAG;

            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            _MMS_LOG[] MMS_LOG;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _MMS_EVENT
        {
            [MarshalAs(UnmanagedType.I8)]
            public long TIME;

            /// <summary>
            /// 송신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_S;

            /// <summary>
            /// 수신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_E;

            [MarshalAs(UnmanagedType.I4)]
            public int SERVICE;

            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RCB_NAME;

            /// <summary>
            /// 리포트 시간 이상 비교시 필요
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long TIMESTAMP;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_MMS_EVENT
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            _MMS_EVENT[] MMS_EVENT;
        }

        /// <summary>
        /// 실시간 갱신용
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _MMS_LOG_DISP
        {
            /// <summary>
            /// PC저장 시간
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            /// <summary>
            /// 송신측 장치 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string SRC_NAME;

            /// <summary>
            /// 수신측 장치 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DEST_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string SERVICE;

            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string MSG;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RCB_NAME;

            /// <summary>
            /// 송신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_S;

            /// <summary>
            /// 수신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_E;

        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_MMS_LOG_DISP
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _MMS_LOG_DISP[] MMS_LOG;
        }

        /// <summary>
        /// 이벤트 Web 디스플레이용
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _MMS_EVT_DISP
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            /// <summary>
            /// 송신측 장치 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string SRC_NAME;

            /// <summary>
            /// 수신측 장치 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DEST_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string SERVICE;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string STATUS;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RCB_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIMESTAMP;

            /// <summary>
            /// 송신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_S;

            /// <summary>
            /// 수신측 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_E;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_MMS_EVT_DISP
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _MMS_EVT_DISP[] MMS_EVENT;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _MMS_SCAN_DISP
        {
            /// <summary>
            /// PC저장 시간
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            /// <summary>
            /// 송신측 장치 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string SRC_NAME;

            /// <summary>
            /// 수신측 장치 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DEST_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RCB_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIMESTAMP;

            /// <summary>
            /// 수신 받은 데이터를 넣는다.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 16)]
            public int[] VALUE;

            /// <summary>
            /// BUFFER_TIME(0), BUFFERED(1), INTEGRITY_PERIOD(2), DataChange(3), QualityChange(4), DataUpdate(5), Intergrity(6), GI(7), Sequence(8), Timestamp(9), ReasonCode(10), Dataset(11),Datareference(12), BufferOverflow(13), EntryID(14), ConfigRevision(15)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 16)]
            public int[] CMP_RES;
        }

        /// <summary>
        /// WEB에서 요청용
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct SHM_MMS_SCAN_DISP
        {
            /// <summary>
            /// 0:평상시, 1:저장 시작, 2:저장 중지
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            /// <summary>
            /// NULL 이면, 전체 IED의 모든 RCB를 버퍼에 저장, IP가 있으면 해당 IED의 모든 RCB를 버퍼에 저장
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string IED_IP_S;

            /// <summary>
            /// NULL 이면, 해당 IED의 모든 RCB를 버퍼에 저장, RCB가 있으면 해당 RCB만 버퍼에 저장
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string RCB_NAME;

            /// <summary>
            /// 비교 옵션, 0:SCL, 1:운영기준
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CHECK_RPT_SELECT;

            /// <summary>
            /// 사용할 운영 기준 설정 정보 위치, REPORT_CFG_INFO 참고
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_REPORT_INDEX;

            /// <summary>
            /// 저장 시간(최소 15초 최대 120초 설정 가능)?
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int TIME_LIMIT;

            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _MMS_SCAN_DISP[] MMS_SCAN;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_MMS
        {
            public SHM_MMS_LOG MMS_LOG;
            public SHM_MMS_EVENT MMS_EVT;
            public SHM_MMS_LOG_DISP MMS_LOG_DISP;
            public SHM_MMS_EVT_DISP MMS_EVT_DISP;
            public SHM_MMS_SCAN_DISP MMS_SCAN_DISP;
        }

        #endregion

        #region GOOSE

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_GOOSE
        {
            public SHM_GOOSE_LOG GOOSE_LOG;
            public SHM_GOOSE_EVENT GOOSE_EVENT;
            public SHM_GOOSE_SCAN GOOSE_SCAN;
            public SHM_GOOSE_LOG_DISP GOOSE_LOG_DISP;
            public SHM_GOOSE_EVT_DISP GOOSE_EVT_DISP;
            public SHM_GOOSE_SCAN_DISP GOOSE_SCAN_DISP;
        }

        /// <summary>
        /// GOOSE 이력 관리, GOOSE의 미송신, 이벤트 등 이력 내용 표시 814byte
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _GOOSE_LOG
        {
            /// <summary>
            /// PC 저장 시간
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long TIME;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;

            /// <summary>
            /// GOOSE 주소
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GOCB_REF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GO_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int APP_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int CONFREV;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATA_SET;

            [MarshalAs(UnmanagedType.I4)]
            public int ST_NUM;

            [MarshalAs(UnmanagedType.I4)]
            public int SQ_NUM;

            [MarshalAs(UnmanagedType.I8)]
            public long TIMESTAMP;

            [MarshalAs(UnmanagedType.I4)]
            public int TAL;

            /// <summary>
            /// GOOSE 로그 작성 당시의 전송 미상태 카운트를 기록하여 이력으로 관리 (GOOSECB 구조체에 들어가는 정보와 동일)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int GSE_CNT_ERR;

            /// <summary>
            /// 이력 상태 (미전송, 이벤트, 미등록 등 상태 표시 0: 정상 1: 미전송 2: 복귀 3: 이벤트 4: 미등록)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SRC_MAC;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_GOOSE_LOG
        {
            /// <summary>
            /// Read 인덱스
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            /// <summary>
            /// Write 인덱스
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _GOOSE_LOG[] GOOSE_LOG;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _GOOSE_LOG_DISP
        {
            /// <summary>
            /// PC저장 시간
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            /// <summary>
            /// IED 이름
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string IED_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_MAC)]
            public string MAC_ADDR;

            /// <summary>
            /// GOOSE 주소
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GOCB_REF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GO_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int APP_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int CONFREV;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATA_SET;

            [MarshalAs(UnmanagedType.I4)]
            public int ST_NUM;

            [MarshalAs(UnmanagedType.I4)]
            public int SQ_NUM;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIMESTAMP;

            [MarshalAs(UnmanagedType.I4)]
            public int TAL;

            [MarshalAs(UnmanagedType.I4)]
            public int GSE_CNT_ERR;

            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            /// <summary>
            /// 이력 상태 (미전송, 이벤트, 미등록 등 상태 표시 0: 정상 1: 미전송 2: 복귀 3: 이벤트 4: 미등록)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string MSG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SIZE_MAC)]
            public byte[] SRC_MAC_ADDR;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_GOOSE_LOG_DISP
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _GOOSE_LOG_DISP[] GOOSE_LOG;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _GOOSE_SCAN
        {
            [MarshalAs(UnmanagedType.I8)]
            public long TIME;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GOCB_REF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GO_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int APP_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int CONFREV;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATASET;

            [MarshalAs(UnmanagedType.I8)]
            public long TIMESTAMP;

            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SRC_MAC;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_GOOSE_SCAN
        {
            /// <summary>
            /// 0 : NONE 1: SCAN 시작 2: SCAN 중지*
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            /// <summary>
            /// 저장 시간 기본 10초, 최대 60초로 설정?
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int TIMELIMIT;

            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _GOOSE_SCAN[] GOOSE_SCN;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _GOOSE_SCAN_DISP
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string IED_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_MAC)]
            public string MAC_ADDR;

            /// <summary>
            /// GOOSE 주소
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GOCB_REF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GO_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int APP_ID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATA_SET;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIMESTAMP;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string STATUS;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_GOOSE_SCAN_DISP
        {
            /// <summary>
            /// 0 : NONE 1: SCAN 시작 2: SCAN 중지
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _GOOSE_SCAN_DISP[] GOOSE_SCAN;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _GOOSE_EVENT
        {
            /// <summary>
            /// PC 저장 시간
            /// </summary>
            [MarshalAs(UnmanagedType.I8)]
            public long TIME;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;

            /// <summary>
            /// GOOSE 주소
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GOCB_REF;

            [MarshalAs(UnmanagedType.I8)]
            public long TIMESTAMP;

            /// <summary>
            /// 이력 상태 (미전송, 이벤트, 미등록 등 상태 표시 0: 정상 1: 미전송 2: 복귀 3: 이벤트 4: 미등록)
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            [MarshalAs(UnmanagedType.I4)]
            public int ST_NUM;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SRC_MAC;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_GOOSE_EVENT
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _GOOSE_EVENT[] GOOSE_EVENT;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _GOOSE_EVT_DISP
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string IED_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GOCB_REF;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string GO_ID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string DATA_SET;

            [MarshalAs(UnmanagedType.I4)]
            public int APP_ID;

            [MarshalAs(UnmanagedType.I4)]
            public int CONFREV;


            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIMESTAMP;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string STATUS;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_MAC)]
            public string MAC_ADDR;

            [MarshalAs(UnmanagedType.I4)]
            public int ST_NUM;


            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SRC_MAC;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_MAC)]
            public string SRC_MAC_ADDR;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_GOOSE_EVT_DISP
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _GOOSE_EVT_DISP[] GOOSE_EVENT;
        }

        #endregion

        #region SNMP

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_SNMP
        {
            public SHM_SNMP_EVENT SNMP_EVT;
            public SHM_SNMP_EVT_DISP SNMP_EVT_DISP;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _SNMP_EVENT
        {
            [MarshalAs(UnmanagedType.I8)]
            public long TIME;

            /// <summary>
            /// 이더넷스위치 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string SWITCH_IP;

            /// <summary>
            /// 이더넷스위치 포트에 연결되어 있는 장치 IP
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string DEVICE_IP;

            [MarshalAs(UnmanagedType.I4)]
            public int PORT;

            /// <summary>
            /// 포트 링크 업/다운 상태	0: 이상 1: 정상
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_SNMP_EVENT
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _SNMP_EVENT[] SNMP_EVENT;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _SNMP_EVT_DISP
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string SWITCH_NAME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_IP)]
            public string DEVICE_NAME;

            [MarshalAs(UnmanagedType.I4)]
            public int PORT;

            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string MSG;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_SNMP_EVT_DISP
        {
            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _SNMP_EVT_DISP[] SNMP_EVENT;
        }


        #endregion

        #region PROC

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct SHM_PROC
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PROC_CNT)]
            public _PROC_MNG[] PROC_MNG;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct _PROC_MNG
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string NAME;

            [MarshalAs(UnmanagedType.I4)]
            public int HEARTBEAT;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public string TIME;

            /// <summary>
            /// 0: 종료 1: 시작
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct SHM_PROC_LOG
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool FLAG;

            [MarshalAs(UnmanagedType.I4)]
            public int READ_INDEX;

            [MarshalAs(UnmanagedType.I4)]
            public int WRITE_INDEX;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EVT_CNT)]
            public _PROC_LOG[] PROC_LOG;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _PROC_LOG
        {
            [MarshalAs(UnmanagedType.I8)]
            public long TIME;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string PROC_NAME;

            [MarshalAs(UnmanagedType.I4)]
            public int STATUS;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string MSG;
        }


        #endregion

        #region REPORT_CFG_INFO

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct REPORT_CFG_INFO
        {
            /// <summary>
            /// 접근 플래그 0,1,2 = 업데이트 안됨
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CB_CNT)]
            public _REPORT_CFG[] REPORT_ITEM;
        }

        /// <summary>
        /// 리포트 (운영)설정 기준
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _REPORT_CFG
        {
            /// <summary>
            /// 설정 명칭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string CFG_NAME;

            /// <summary>
            /// 버퍼 타임
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_BUFFER_TIME;

            /// <summary>
            /// 버퍼드
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_BUFFERED;

            /// <summary>
            /// 전송 주기
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int CFG_INTEGRITY_PERIOD;

            /// <summary>
            /// DataChange(0), QualityChange(1), DataUpdate(2), Intergrity(3), GI(4)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 5)]
            public int[] CFG_TRIGGER_OPTION;

            /// <summary>
            /// Sequence(0), Timestamp(1), ReasonCode(2), Dataset(3), Datareference(4), BufferOverflow(5), EntryID(BUF), ConfigRevision(7)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 8)]
            public int[] CFG_OPTION_FIELD;

            /// <summary>
            /// DataChange(0), QualityChange(1), DataUpdate(2), Intergrity(3), GI(4)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string TRIGGER_OPTION_DISP;

            /// <summary>
            /// Sequence(0), Timestamp(1), ReasonCode(2), Dataset(3),Datareference(4), BufferOverflow(5), EntryID(BUF), ConfigRevision(7)
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string OPTION_FIELD_DISP;
        }

        #endregion

        #region STRING_BUF

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct STRING_BUF
        {
            /// <summary>
            /// 0 : NONE 1: CHANGE
            /// </summary>
            [MarshalAs(UnmanagedType.I4)]
            public int FLAG;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string IN_BUF;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SIZE_STRING)]
            public string OUT_BUF;

        }

        #endregion

    }


    #region SMD_E

    public struct USER_INFO_E
    {
        public bool isAuth;
        public string id;
        public string pw;
        public int level;
        public int logoutMin;

        /// <summary>
        /// 즐겨찾기 리스트 ':' 로 구분
        /// </summary>
        public string linkList;
    }

    public struct HMI_INFO_E
    {
        public int id;
        public string hmi_ip;
        public string hmi_name;
    }

    public struct HMI_INFO_M
    {
        public int type;
        public int variable;
        public string hmiName;
        public string hmiIp;
        public string timeOut;
    }


    public struct BASIC_STATUS_E
    {
        public int sts_nms;
        public int sts_fuction;
        public int sts_mms_trs;
        public int sts_report_err;
        public int sts_goose_err;
        public int sts_goose_mis;
        public int sts_sntp_err;
        public int sntp_sync_fail;
    }

    public struct BASIC_STATUS_M
    {
        public int tempValue;
    }

    public struct DRIVE_E
    {
        public string name;
        public string total_space;
        public string free_space;
        public string usage_space;
    }

    public struct SYS_INFO_E
    {
        public DRIVE_E[] drives;
        public int cpu_share;
        public int cpu_max;
        public int memory_share;
        public int memory_max;
        public int network_share;
        public int network_max;
    }

    public struct NIC_INFO_E
    {
        public bool result;
        public int enable;
        public List<string> name;
        public List<string> ip;
        public List<string> desc;
    }

    public struct PROC_STATUS_E
    {
        public int mms_mon;
        public int pkt_save;
        public int goose_mon;
        public int snmp_mon;
        public int sntp;
        public int iec61850;
        public int scl_proc;
        public int rpt_out;
        public int filter_mng;
        public string mms_mon_time;
        public string pkt_save_time;
        public string goose_mon_time;
        public string snmp_mon_time;
        public string sntp_time;
        public string iec61850_time;
        public string scl_proc_time;
        public string rpt_out_time;
        public string filter_mng_time;
    }

    public struct PROC_STATUS_M
    {
        public int flag;
        public int value;
    }

    public struct PROC_EVT_E
    {
        public int index;
        public string time;
        public string proc_name;
        public int status;
        public string msg;
    }

    public struct STANDARD_INFO_E
    {
        public int check_time_goose;
        public int check_time;
        public int goose_scan_time;
        public int report_scan_time;
        public int check_sntp_gap;
        public int time_offset;
        public string sntp_ip;
        public int sntp_timer;
        public string sntp_sync_time;
        public int sntp_sync_fail;
        public double del_space_ratio;
        public int log_out_timer;

    }

    public struct OP_STANDARD_INFO_E
    {
        public int id;
        public string type;
        public string cfg_name;
        public int cfg_buffer_time;
        public int cfg_buffered;
        public int cfg_integrity_period;
        public int cfg_trigger_option0;
        public int cfg_trigger_option1;
        public int cfg_trigger_option2;
        public int cfg_trigger_option3;
        public int cfg_trigger_option4;
        public int cfg_option_field0;
        public int cfg_option_field1;
        public int cfg_option_field2;
        public int cfg_option_field3;
        public int cfg_option_field4;
        public int cfg_option_field5;
        public int cfg_option_field6;
        public int cfg_option_field7;
        public string trigger_option_disp;
        public string option_field_disp;
    }



    public struct STANDARD_RPT_M
    {
        public int rpt_miss;
        public int rpt_scan;
        public int gap;
        public int offset;
    }

    public struct STANDARD_GSE_M
    {
        public int rpt_miss;
        public int rpt_scan;
    }

    public struct ENABLE_INFO_E
    {
        public string type;
        public string name;
        public string ip;
        public int runMMS;
        public int runGOOSE;
    }

    #endregion

    #region IED_E
    public struct IED_INFO_E
    {
        public string type;
        public string ied_name;
        public string ied_ip;
        public int hmi;
        public int gw1;
        public int gw2;
        public int goose;
        public int rcb_count;
        public int gocb_count;
        public int run_stop_mms;
        public int run_stop_goose;
        public string cid_file;
        public string iet_file;
    }

    public struct REPORT_CB_INFO_E
    {
        public string rcb_name;
        public string report_id;
        public int buffer_time;
        public int buffered;
        public int integrity_period;
        public int trigger_option0;
        public int trigger_option1;
        public int trigger_option2;
        public int trigger_option3;
        public int trigger_option4;
        public int option_field0;
        public int option_field1;
        public int option_field2;
        public int option_field3;
        public int option_field4;
        public int option_field5;
        public int option_field6;
        public int option_field7;
        public string ied_ip;
        public string ied_name;
        public string dest_device_name;
        public int rpt_status;
        public int rpt_cnt_err;
        public int rpt_cnt_tot;
        public int rpt_cnt_evt;
        public string rpt_timestamp;
        public int rpt_gap_max;
        public int rpt_gap_min;

    }

    public struct REPORT_CB_INFO_M
    {
        public string iedIp;
        public int rptIndex;
        public int period;
    }

    public struct GOOSE_INFO_M
    {
        public string iedIp;
        public string macAddr;
        public int rptIndex;
        public int period;
    }

    public struct CLEARMEM_INFO
    {
        public int setValue;
    }

    public struct GOOSE_CB_INFO_E
    {
        public string gocb_name;
        public string go_id;
        public string ied_name;
        public string dataset_name;
        public string mac_addr;
        public int app_id;
        public int confrev;
        public int max;
        public int gse_status;
        public int gse_seq_no;
        public int gse_sts_no;
        public int gse_tal;
        public int gse_cnt_err;
        public string gse_timestamp;
        public string ied_ip;
    }

    public struct REQ_ENABLE_M
    {
        public string hmi_ip;
        public int runMMS;
        public int runGOOSE;
        public int type;
    }

    public struct REQ_IED_M
    {
        public int id;
        public string buf1;
        public string buf2;
        public int timeout;
    }

    public struct REQ_IED_E
    {
        public string result;
        public string msg;
    }


    public struct REQ_SCL_M
    {
        public string buf1;
        public string buf2;
        public int timeout;
    }

    public struct REQ_SCL_E
    {
        public string result;
        public string op_name;
        public List<int> res_cmp;
    }

    public struct REQ_SEARCH_EVT_M
    {
        public string time_start;
        public string time_end;
        public int type;
        public int timeout;
    }

    public struct REQ_SEARCH_EVT_E
    {
        public string result;
        public string file;

    }

    public struct REQ_PACKET_SAVE_M
    {
        public string time_start;
        public string time_end;
        public string token;
        public int type;
        public int timeout;
        public int count;
        public int all;
    }

    public struct REQ_PACKET_SAVE_E
    {
        public string result;
        public string file;

    }

    public struct REQ_EDIT_HMI_M
    {
        public string buff1;
        public string buff2;
        public string buff3;
        public string buff4;
        public int timeout;
    }

    public struct REQ_EDIT_HMI_E
    {
        public int result;
    }

    public struct REQ_EDIT_SYS_M
    {
        public int flag;
    }

    public struct OP_STANDARD_M
    {
        public int id;
        public int timeout;
        public string in_buff;
        public int cfg_trigger_option;
        public int cfg_option_field;
    }

    public struct OP_STANDARD_E
    {
        public int result;
    }

    public struct REQ_ALL_E
    {
        public int id;
        public string type;
        public string name;
        public string ip;

    }

    #endregion

    #region SWITCH_E

    public struct SWITCH_PORT_E
    {
        public string switch_port_dev_ip;
        public int switch_port_status;
        public string switch_device_name;
        public int switch_init_flag;
    }

    public struct SWITCH_E
    {
        public int id;
        public string type;
        public string switch_name;
        public string switch_ip;
        public int switch_seq;
        public int switch_port_count;
        public int switch_status;

        public SWITCH_PORT_E[] portArr;
    }

    public struct PORT_ITEM_E
    {
        public int status;
        public string info;
        public string name;
        public int init;
    }

    public struct PORT_INFO_E
    {
        public int id;
        public string type;
        public string name;
        public string ip;
        public int count;
        public int status;
        public PORT_ITEM_E[] portArr;
    }

    public struct SWITCH_INFO_M
    {
        public int id;
        public string switch_name;
        public string switch_ip;
        public int type;
        public int port;
        public int timeout;
    }

    public struct SWITCH_PORT_M
    {
        /// <summary>
        ///  ??????????
        /// </summary>
        public int id;
    }

    #endregion

    #region MMS_E

    public struct MMS_LOG_E
    {
        public string time;
        public string src_name;
        public string dest_name;
        public string service;
        public int status;
        public string msg;
        public string rcb_name;
    }

    public struct REPORT_EVT_E
    {
        public string time;
        public string src_name;
        public string dest_name;
        public string service;
        public string msg;
        public string timestamp;
        public string rcb_name;
    }

    public struct REPORT_SCAN_E
    {
        public string time;
        public string src_name;
        public string dest_name;
        public string rcb_name;
        public List<int> value;
        public List<int> cmp_res;

    }

    public struct REPORT_SCAN_REQ
    {
        public int flag;
        public int number;
        public string tmpValue;
        public string tmpValue2;
    }

    #endregion

    #region GOOSE_E
    public struct GOOSE_LOG_E
    {
        public string time;
        public string ied_name;
        public string mac_addr;
        public string gocb_ref;
        public int status;
        public int st_num;
        public string msg;
    }

    public struct GOOSE_EVT_E
    {
        public string time;
        public string ied_name;
        public string gocb_ref;
        public string msg;
        public string timestamp;
        public string mac_addr;
        public int st_num;
    }

    public struct GOOSE_SCAN_E
    {
        public string time;
        public string ied_name;
        public string gocb_ref;
        public string go_id;
        public string status;
        public string mac_addr;
        public string data_set;
    }

    #endregion

    #region SNMP
    public struct SNTP_EVT_E
    {
        public string time;
        public string switch_name;
        public string device_name;
        public int status;
        public string msg;
        public int port;
    }

    public struct SNTP_STANDARD_M
    {
        public string sntp_ip;
        public int sntp_time;

    }

    #endregion



}

