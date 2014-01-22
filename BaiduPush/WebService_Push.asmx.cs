using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BaiduPushWebService
{
    /// <summary>
    /// WebService_Push 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebService_Push : WebService
    {
        /// <summary>
        /// 通知推送接口
        /// </summary>
        /// <param name="strJson">{"title":"标题","des":"描述","deviceType":"3：Andriod设备；4：iOS设备；","pushType":"1：单个人 2：一群人，必须指定 tag 3：所有人","tag":"标签名","userID":"不是必须","channelID":"不是必须","msgType":"0：消息（透传给应用的消息体）1：通知（对应设备上的消息通知）"}</param>
        /// <returns></returns>
        [WebMethod]
        public string PushMsg(string strJson)
        {
            string result = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<string, string> dic = json.Deserialize<Dictionary<string, string>>(strJson);
                BaiduPush Bpush = new BaiduPush("POST");
                String messages = "";
                String method = "push_msg";
                TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
                uint device_type = uint.Parse(dic["deviceType"]);
                uint unixTime = (uint)ts.TotalSeconds;
                string messageksy = "pushkeys";
                string apiKey = SysFunction.GetConfigValue("ApiKey");

                if (device_type == 4)
                {
                    IOSNotification notification = new IOSNotification();
                    notification.title = dic["title"];
                    notification.description = dic["des"];
                    messages = notification.getJsonString();
                }
                else if (device_type == 3)
                {
                    AndroidNotification notification = new AndroidNotification();
                    notification.title = dic["title"];
                    notification.description = dic["des"];
                    messages = notification.getJsonString();
                }

                PushOptions pOpts;
                if (dic["pushType"].Equals("1"))
                {
                    pOpts = new PushOptions(method, apiKey, dic["userID"], dic["channelID"], device_type, messages, messageksy, unixTime);
                }
                else if (dic["pushType"].Equals("2"))
                {
                    pOpts = new PushOptions(method, apiKey, dic["tag"], device_type, messages, messageksy, unixTime);
                }
                else
                {
                    pOpts = new PushOptions(method, apiKey, device_type, messages, messageksy, unixTime);
                }

                pOpts.message_type = uint.Parse(dic["msgType"]);

                message = Bpush.PushMessage(pOpts);
                result = "0";
            }
            catch (Exception ex)
            {
                HandleException(ex, ref result, ref message);
            }
            return GetResultStr(result, message);
        }

        /// <summary>
        /// 设置标签
        /// </summary>
        /// <param name="strJson">{"tag":"标签名","userID":"用户ID"}</param>
        /// <returns></returns>
        [WebMethod]
        public string SetTag(string strJson)
        {
            string result = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<string, string> dic = json.Deserialize<Dictionary<string, string>>(strJson);
                TagOperation(dic["userID"], dic["tag"], "set_tag", ref result, ref message);
            }
            catch (Exception ex)
            {
                HandleException(ex, ref result, ref message);
            }
            return GetResultStr(result, message);
        }

        /// <summary>
        /// 删除标签 当user_id被提交时，服务端将只会完成解除该用户与tag绑定关系的操作。
        /// </summary>
        /// <param name="strJson">{"tag":"标签名","userID":"用户ID"}</param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteTag(string strJson)
        {
            string result = string.Empty;
            string message = string.Empty;
            try
            {
                Dictionary<string, string> dic = json.Deserialize<Dictionary<string, string>>(strJson);
                TagOperation(dic["userID"], dic["tag"], "delete_tag", ref result, ref message);
            }
            catch (Exception ex)
            {
                HandleException(ex, ref result, ref message);
            }
            return GetResultStr(result, message);
        }

        #region 私有方法

        /// <summary>
        /// 标签操作
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="tag">标签名</param>
        /// <param name="method">方法名</param>
        /// <param name="result"></param>
        /// <param name="message"></param>
        private void TagOperation(string userId, string tag, string method, ref string result, ref string message)
        {
            BaiduPush Bpush = new BaiduPush("POST");
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            uint unixTime = (uint)ts.TotalSeconds;
            string apiKey = SysFunction.GetConfigValue("ApiKey");

            TagOptions tOpts = new TagOptions(method, apiKey, userId, tag, unixTime);

            message = Bpush.SetTag(tOpts);
            result = "0";
        }

        #endregion
    }
}
