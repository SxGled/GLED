namespace Winsoft.WorkSystem.Common.Json
{
    public class ReturnJson
    {
        public int? ErrorCode { get; set; }//错误码
        public object ErrorMsg { get; set; }//错误返回的数据
        public object Data { get; set; }//成功返回的数据
        public bool Success { get; set; }//是否执行成功
        public int HttpCode { get; set; }//http状态码
        public string CheckParamsSuccess { get; set; }// 内部跳转 ok表示校验通过   no表示校验不通过
    }
}
