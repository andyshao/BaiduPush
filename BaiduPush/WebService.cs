using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;

namespace BaiduPushWebService
{
    public class WebService : System.Web.Services.WebService
    {
        #region 公共属性

        //json序列化对象
        protected static JavaScriptSerializer json = new JavaScriptSerializer();

        //应用程序根路径
        protected static string _strFilePath = AppDomain.CurrentDomain.BaseDirectory;

        //日志对象
        protected static readonly log4net.ILog logError = log4net.LogManager.GetLogger("logerror");

        #endregion

        #region 公共方法

        #region 得到返回的Json数据

        /// <summary>
        /// 得到返回结果 Json数据
        /// </summary>
        /// <param name="result">结果代码</param>
        /// <param name="message">结果信息</param>
        /// <returns></returns>
        protected string GetResultStr(string result, string message)
        {
            string returnStr = string.Empty;
            if (SysFunction.IsJson(message))
            {
                returnStr = string.Format("{{\"result\":\"{0}\",\"message\":{1}}}", result, message);
            }
            else
            {
                returnStr = string.Format("{{\"result\":\"{0}\",\"message\":\"{1}\"}}", result, message);
            }
            return returnStr;
        }

        #endregion

        #region 检查文件夹是否存在

        /// <summary>
        /// 检查文件夹是否存在
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns>false:文件夹不存在，true：文件夹存在</returns>
        protected bool DirectoryExistsFile(string FilePath)
        {
            if (!Directory.Exists(FilePath))
                return false;
            else
                return true;
        }

        #endregion

        #region 检查文件是否存在

        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns>false:文件不存在，true：文件存在</returns>
        protected bool FileExistsFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                return false;
            else
                return true;
        }

        #endregion

        #region 删除本地文件

        /// <summary>
        /// 删除本地文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns>false:文件夹不存在，true：文件夹存在</returns>
        protected void DeleteFile(string FilePath)
        {
            File.Delete(FilePath);
        }

        #endregion

        #region 写错误日志到文件中

        /// <summary>
        /// 写错误日志到文件中
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ex"></param>
        protected void WriteErrorLog(string info, Exception ex)
        {
            if (logError.IsErrorEnabled)
            {
                logError.Error(info, ex);
            }
        }

        #region 异常处理

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="result"></param>
        /// <param name="message"></param>
        protected void HandleException(Exception ex, ref string result, ref string message)
        {
            message = ex.Message;
            result = "500";
            WriteErrorLog("IP:" + Context.Request.UserHostAddress + " url:" + Context.Request.Url, ex);
        }

        #endregion

        #endregion

        #endregion

    }
}