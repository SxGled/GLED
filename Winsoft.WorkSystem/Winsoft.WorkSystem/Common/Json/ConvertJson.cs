using Newtonsoft.Json;

namespace Winsoft.WorkSystem.Common.Json
{
    public class ConvertJson
    {
       /// <summary>
       /// 将对象转换成string
       /// </summary>
       /// <typeparam name="ObjType"></typeparam>
       /// <param name="obj"></param>
       /// <returns></returns>
        public static string ObjToJsonString<ObjType>(ObjType obj) where ObjType : class
        {
            string s = JsonConvert.SerializeObject(obj);
            return s;
        }
        /// <summary>
        /// 将string转换成对象
        /// </summary>
        /// <typeparam name="ObjType"></typeparam>
        /// <param name="JsonString"></param>
        /// <returns></returns>
        public static ObjType JsonStringToObj<ObjType>(string JsonString) where ObjType : class
        {
            ObjType s = JsonConvert.DeserializeObject<ObjType>(JsonString);
            return s;
        }

    }
}
