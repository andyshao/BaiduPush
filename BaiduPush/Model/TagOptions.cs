using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiduPushWebService
{
    public class TagOptions
    {
        public string method { get; set; } 	//string 	是 	方法名，必须存在：push_msg。
        public string apikey { get; set; }	//string 	是 	访问令牌，明文AK，可从此值获得App的信息，配合sign中的sk做合法性身份认证。
        public string user_id { get; set; }	//string 	否 	用户标识，在Android里，channel_id + userid指定某一个特定client。不超过256字节，如果存在此字段，则只推送给此用户。
        public string tag { get; set; }	//string 	否 	标签名称，不超过128字节
        public uint timestamp { get; set; }	//uint 	是 	用户发起请求时的unix时间戳。本次请求签名的有效时间为该时间戳+10分钟。
        public string sign { get; set; } 	//string 	是 	调用参数签名值，与apikey成对出现。
        public uint? expires { get; set; }//	uint 	否 	用户指定本次请求签名的失效时间。格式为unix时间戳形式。
        public uint? v { get; set; }	//uint 	否 	API版本号，默认使用最高版本。

        public TagOptions
        (
           string method,
           string apikey,
           string user_id,
           string tag,
           uint timestamp
        )
        {
            this.method = method;
            this.apikey = apikey;
            this.user_id = user_id;
            this.timestamp = timestamp;
            this.tag = tag;
        }
    }
}