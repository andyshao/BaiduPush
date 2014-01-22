using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.CSharp;
using System.Xml.Linq;

namespace BaiduPushWebService
{
    public class SysFunction
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public SysFunction()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #endregion

        #region 方法

        #region 数字转换成布尔型
        /// <summary>
        /// 数字转换成布尔型
        /// </summary>
        /// <param name="data">数字</param>
        /// <returns>布尔值</returns>
        public static bool BooleanParser(float data)
        {
            if (data == 0)
                return false;
            else if (data == 1)
                return true;
            else
                return false;
        }
        #endregion

        #region 布尔型转换成数字
        /// <summary>
        /// 布尔型转换成数字
        /// </summary>
        /// <param name="data">布尔值</param>
        /// <returns>数字</returns>
        public static int BooleanParser(bool data)
        {
            if (data)
                return 1;
            else
                return 0;
        }
        #endregion

        #region 对象转换成对象
        /// <summary>
        /// 对象转换成传入的对象
        /// </summary>
        /// <param name="p_objValue">传入的对象</param>
        /// <param name="p_objDefaultValue">默认的对象</param>
        /// <returns>对象为空返回默认的对象,否则返回该对象本身</returns>
        public static object ObjectToObject(object p_objValue, object p_objDefaultValue)
        {
            try
            {
                if (p_objValue == null || p_objValue == System.DBNull.Value
                    || p_objValue.ToString().Trim() == "")
                {
                    return p_objDefaultValue;
                }
                else
                {
                    return p_objValue;
                }
            }
            catch
            {
                return p_objDefaultValue;
            }
        }
        #endregion

        #region 对象转换成字符串
        /// <summary>
        /// 对象转换成的字符串
        /// </summary>
        /// <param name="p_objValue">传入的对象</param>
        /// <param name="p_strDefaultValue">默认的字符串</param>
        /// <returns>对象为空返回默认的字符串,否则返回该对象字符串形式</returns>
        public static string ObjectToString(object p_objValue, string p_strDefaultValue)
        {
            try
            {
                if (p_objValue == null || p_objValue == System.DBNull.Value
                    || p_objValue.ToString().Trim() == "")
                {
                    return p_strDefaultValue;
                }
                else
                {
                    return p_objValue.ToString().Trim();
                }
            }
            catch
            {
                return p_strDefaultValue;
            }
        }
        #endregion

        #region 对象转换成字符串(默认)
        /// <summary>
        /// 对象转换成字符串
        /// </summary>
        /// <param name="p_objValue">传入的对象</param>
        /// <returns>对象为空返回空字符串,否则返回该对象字符串形式</returns>
        public static string ObjectToString(object p_objValue)
        {
            try
            {
                if (p_objValue == null || p_objValue == System.DBNull.Value
                    || p_objValue.ToString().Trim() == "")
                {
                    return "";
                }
                else
                {
                    return p_objValue.ToString().Trim();
                }
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 对象转换成整数
        /// <summary>
        /// 对象转换成整数
        /// </summary>
        /// <param name="p_objValue">传入的对象</param>
        /// <param name="p_intDefaultValue">默认的整数</param>
        /// <returns>对象为空返回默认的数字,否则返回该对象的整数形式</returns>
        public static int ObjectToInt(object p_objValue, int p_intDefaultValue)
        {
            try
            {
                if (p_objValue == null || p_objValue == System.DBNull.Value
                    || p_objValue.ToString().Trim() == "")
                {
                    return p_intDefaultValue;
                }
                else
                {
                    return int.Parse(p_objValue.ToString().Trim());
                }
            }
            catch
            {
                return p_intDefaultValue;
            }
        }
        #endregion

        #region 对象转换成整数(默认)
        /// <summary>
        /// 对象转换成整数
        /// </summary>
        /// <param name="p_objValue">传入的对象</param>
        /// <returns>对象为空返回0,否则返回该对象的整数形式</returns>
        public static int ObjectToInt(object p_objValue)
        {
            try
            {
                if (p_objValue == null || p_objValue == System.DBNull.Value
                    || p_objValue.ToString().Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return int.Parse(p_objValue.ToString().Trim());
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 对象转换成小数
        /// <summary>
        /// 对象转换成小数
        /// </summary>
        /// <param name="p_objValue">传入的对象</param>
        /// <param name="p_dblDefaultValue">默认的小数</param>
        /// <returns>对象为空返回默认的小数,否则返回该对象的小数形式</returns>
        public static double ObjectToDouble(object p_objValue, double p_dblDefaultValue)
        {
            try
            {
                if (p_objValue == null || p_objValue == System.DBNull.Value
                    || p_objValue.ToString().Trim() == "")
                {
                    return p_dblDefaultValue;
                }
                else
                {
                    return double.Parse(p_objValue.ToString().Trim());
                }
            }
            catch
            {
                return p_dblDefaultValue;
            }
        }
        #endregion

        #region 对象转换成小数(默认)
        /// <summary>
        /// 对象转换成小数(默认)
        /// </summary>
        /// <param name="p_objValue">传入的对象</param>
        /// <returns>对象为空返回0,否则返回该对象的小数形式</returns>
        public static double ObjectToDouble(object p_objValue)
        {
            try
            {
                if (p_objValue == null || p_objValue == System.DBNull.Value
                    || p_objValue.ToString().Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return double.Parse(p_objValue.ToString().Trim());
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 字符串转换成字符串
        /// <summary>
        /// 字符串转换成字符串
        /// </summary>
        /// <param name="p_strValue">传入的字符串</param>
        /// <param name="p_strDefaultValue">默认的字符串</param>
        /// <returns>字符串为空返回默认的字符串,否则返回字符串本身</returns>
        public static string StringToString(string p_strValue, string p_strDefaultValue)
        {
            try
            {
                if (p_strValue == null || p_strValue.Trim() == "")
                {
                    return p_strDefaultValue;
                }
                else
                {
                    return p_strValue.Trim();
                }
            }
            catch
            {
                return p_strDefaultValue;
            }
        }
        #endregion

        #region 字符串转换成整数
        /// <summary>
        /// 字符串转换成整数
        /// </summary>
        /// <param name="p_strValue">传入的字符串</param>
        /// <param name="p_intDefaultValue">默认的整数</param>
        /// <returns>字符串为空返回默认的数字,否则返回字符串的整数形式</returns>
        public static int StringToInt(string p_strValue, int p_intDefaultValue)
        {
            try
            {
                if (p_strValue == null || p_strValue.Trim() == "")
                {
                    return p_intDefaultValue;
                }
                else
                {
                    return int.Parse(p_strValue.Trim());
                }
            }
            catch
            {
                return p_intDefaultValue;
            }
        }
        #endregion

        #region 字符串转换成整数(默认)
        /// <summary>
        /// 字符串转换成整型
        /// </summary>
        /// <param name="p_strValue">传入的字符串</param>
        /// <returns>字符串为空返回0，否则返回字符串的整数形式</returns>
        public static int StringToInt(string p_strValue)
        {
            try
            {
                if (p_strValue == null || p_strValue.Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return int.Parse(p_strValue.Trim());
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 字符串转换成小数
        /// <summary>
        /// 字符串转换成小数
        /// </summary>
        /// <param name="p_strValue">传入的字符串</param>
        /// <param name="p_dblDefaultValue">默认的小数</param>
        /// <returns>字符串为空返回默认的小数,否则返回字符串的小数形式</returns>
        public static double StringToDouble(string p_strValue, double p_dblDefaultValue)
        {
            try
            {
                if (p_strValue == null || p_strValue.Trim() == "")
                {
                    return p_dblDefaultValue;
                }
                else
                {
                    return double.Parse(p_strValue.Trim());
                }
            }
            catch
            {
                return p_dblDefaultValue;
            }
        }
        #endregion

        #region 字符串转换成小数(默认)
        /// <summary>
        /// 字符串转换成小数(默认)
        /// </summary>
        /// <param name="p_strValue">传入的字符串</param>
        /// <returns>字符串为空返回0,否则返回字符串的小数形式</returns>
        public static double StringToDouble(string p_strValue)
        {
            try
            {
                if (p_strValue == null || p_strValue.Trim() == "")
                {
                    return 0;
                }
                else
                {
                    return double.Parse(p_strValue.Trim());
                }
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 小数转换成字符串
        /// <summary>
        /// 小数转换成字符串
        /// </summary>
        /// <param name="p_dblValue">传入的小数</param>
        /// <param name="p_strDefaultValue">默认的字符串</param>
        /// <returns>小数为0返回默认字符串,否则返回小数的字符串形式</returns>
        public static string DoubleToString(double p_dblValue, string p_strDefaultValue)
        {
            try
            {
                if (p_dblValue == 0)
                {
                    return p_strDefaultValue;
                }
                else
                {
                    return p_dblValue.ToString().Trim();
                }
            }
            catch
            {
                return p_strDefaultValue;
            }
        }
        #endregion

        #region 小数转换成字符串(默认)
        /// <summary>
        /// 小数转换成字符串(默认)
        /// </summary>
        /// <param name="p_dblValue">传入的小数</param>
        /// <returns>小数为0返回空字符串,否则返回小数的字符串形式</returns>
        public static string DoubleToString(double p_dblValue)
        {
            try
            {
                if (p_dblValue == 0)
                {
                    return "";
                }
                else
                {
                    return p_dblValue.ToString().Trim();
                }
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 得到数字的百分比形式,如果为"—"则原样返回
        /// <summary>
        /// 得到数字的百分比形式,如果为"—"则原样返回
        /// </summary>
        /// <param name="p_strNum">传入的数字</param>
        /// <returns>数字的百分比形式,如果为"—"则原样返回</returns>
        public static string GetNumPercent(string p_strNum)
        {
            if (p_strNum.Trim() != "—")
            {
                return p_strNum.Trim() + "%";
            }
            else
            {
                return p_strNum.Trim();
            }
        }
        #endregion

        #region 根据路径得到二进制流
        /// <summary>
        /// 根据路径得到二进制流
        /// </summary>
        /// <param name="p_strPath">传入的路径</param>
        /// <returns>二进制流</returns>
        public static byte[] GetByte(string p_strPath)
        {
            Stream stream = File.Open(p_strPath, FileMode.Open);
            byte[] bteContent = new byte[stream.Length + 10];
            stream.Read(bteContent, 0, bteContent.Length);
            stream.Close();
            return bteContent;
        }
        #endregion

        #region 将指定路径文件写入二进制流
        /// <summary>
        /// 将指定路径文件写入二进制流
        /// </summary>
        /// <param name="p_strPath"></param>
        /// <returns></returns>
        public static byte[] TransFileToByte(string p_strPath)
        {
            byte[] bteContent = null;
            try
            {
                FileStream fsReader = new FileStream(p_strPath, FileMode.Open, FileAccess.Read);
                BinaryReader bReader = new BinaryReader(fsReader);
                bteContent = bReader.ReadBytes((int)fsReader.Length);

                fsReader.Close();
                bReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bteContent;
        }
        #endregion

        #region 将二进制流写入指定路径文件
        /// <summary>
        /// 将二进制流写入指定路径文件
        /// </summary>
        /// <param name="p_strPath"></param>
        /// <param name="p_bteContent"></param>
        /// <returns>false写入失败 true 写入成功</returns>
        public static bool TransByteToFile(string p_strPath, byte[] p_bteContent)
        {
            bool blResult = false;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(p_strPath)))
                {
                    DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(p_strPath));
                    dir.Create();
                }
                FileStream fsWrite = new FileStream(p_strPath, FileMode.Create, FileAccess.Write);
                BinaryWriter bWrite = new BinaryWriter(fsWrite);
                bWrite.Write(p_bteContent);

                fsWrite.Close();
                bWrite.Close();
                blResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blResult;
        }
        #endregion

        #region 根据文件扩展名返回代表系统的Content-Type类型

        /// <summary>
        /// 根据文件扩展名返回代表系统的Content-Type类型
        /// </summary>
        /// <param name="suffix">文件扩展名</param>
        /// <returns></returns>
        public static string GetContentType(string suffix)
        {
            string resturn = "text/html";
            if (string.IsNullOrEmpty(suffix)) return resturn;

            switch (suffix.ToLower())
            {
                case ".bmp":
                    resturn = "image/jpeg";
                    break;
                case ".jpg":
                    resturn = "image/jpeg";
                    break;
                case ".gif":
                    resturn = "image/jpeg";
                    break;
                case ".doc":
                    resturn = "application/msword";
                    break;
                case ".xls":
                    resturn = "application/vnd.ms-excel";
                    break;
                case ".xml":
                    resturn = "text/xml";
                    break;
                case ".ppt":
                    resturn = "application/vnd.ms-powerpoint";
                    break;
                case ".rar":
                case ".zip":
                    resturn = "application/octet-stream";
                    break;
                case ".mht":
                    resturn = "message/rfc822";
                    break;
                case ".txt":
                    resturn = "text/plain";
                    break;
            }

            return resturn;
        }

        #endregion

        #region 将二进制流转换成字符串
        /// <summary>
        /// 将二进制流转换成字符串
        /// </summary>
        /// <param name="p_bteContent">二进制流</param>
        /// <returns>流的字符形式</returns>
        public static string ByteToBase64String(byte[] p_bteContent)
        {
            string strRtnValue = "";
            try
            {
                if (p_bteContent != null)
                {
                    strRtnValue = Convert.ToBase64String(p_bteContent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strRtnValue;
        }
        #endregion

        #region 将字符串转换成二进制流
        /// <summary>
        /// 将字符串转换成二进制流
        /// </summary>
        /// <param name="p_strContent">二进制流</param>
        /// <returns>流的字符形式</returns>
        public static byte[] Base64StringToBtye(string p_strContent)
        {
            byte[] bteContent = null;
            try
            {
                if (p_strContent != "")
                {
                    bteContent = Convert.FromBase64String(p_strContent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bteContent;
        }
        #endregion

        #region 根据指定长度截取字符串
        /// <summary>
        /// 根据指定长度截取字符串
        /// </summary>
        /// <param name="p_strText">传入的字符串</param>
        /// <param name="p_intLength">截取的长度</param>
        /// <returns>截取后的字符串</returns>
        public static string GetStringByLength(string p_strText, int p_intLength)
        {
            int intLength = p_intLength;//截取总长度
            string strResult = "";//截取后的字符串
            byte[] byteText = new byte[p_strText.Length];

            for (int i = 0; i < p_strText.Length; i++)
            {
                string strTemp = p_strText.Substring(i, 1);
                byteText = System.Text.Encoding.Default.GetBytes(strTemp);

                if (intLength > 0)//还剩余长度则逐字添加到新字符串中
                {
                    strResult += strTemp;
                }

                //byteText.Length等于1:半脚英文或数字 等于2:全角中文
                intLength = intLength - byteText.Length;
            }

            return strResult;
        }
        #endregion

        #region 停止进程(限定进程开启时间)
        /// <summary> 
        /// 停止进程 
        /// </summary> 
        /// <param name="p_processName">进程名称</param > 
        /// <param name="p_dteBeforeStartTime">进程启动前的时间</param> 
        /// <param name="p_dteAfterStartTime">进程启动后的时间</param> 
        public static void KillProcess(string p_processName, DateTime p_dteBeforeStartTime,
            DateTime p_dteAfterStartTime)
        {
            Process[] processList;
            DateTime dteProcessStartTime;

            try
            {
                processList = Process.GetProcessesByName(p_processName);

                foreach (Process tmpProcess in processList)
                {
                    dteProcessStartTime = tmpProcess.StartTime;
                    if (dteProcessStartTime.CompareTo(p_dteBeforeStartTime) > 0
                        && dteProcessStartTime.CompareTo(p_dteAfterStartTime) < 0)
                    {
                        tmpProcess.Kill();
                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 停止进程(不限定进程开启时间)
        /// <summary> 
        /// 停止进程 
        /// </summary> 
        /// <param name="p_processName">进程名称</param > 
        public static void KillProcess(string p_processName)
        {
            Process[] processList;

            try
            {
                processList = Process.GetProcessesByName(p_processName);

                foreach (Process tmpProcess in processList)
                {
                    tmpProcess.Kill();
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 截取小数点后面的0
        /// <summary>
        /// 截取小数点后面的0
        /// </summary>
        /// <param name="p_strDecimal">传入的小数</param>
        /// <returns>截取后的小数</returns>
        public static string InterceptZero(string p_strDecimal)
        {
            string strDecimal = p_strDecimal;

            if (p_strDecimal.IndexOf(".") != -1)//小数
            {
                for (int i = strDecimal.Length - 1; i > 0; i--)
                {
                    if (i != strDecimal.Length)
                    {
                        if (strDecimal.Substring(i, 1) == ".")//小数点后都是0则只显示整数部分
                        {
                            strDecimal = strDecimal.Substring(0, i);
                            break;
                        }
                    }

                    if (strDecimal.Substring(i, 1) == "0")//当前位数是0
                    {
                        strDecimal = strDecimal.Substring(0, i);//截取小数点后的0
                    }
                    else //当前位数不是0则没必要继续截取
                    {
                        break;
                    }
                }
            }

            return strDecimal;
        }
        #endregion

        #region 得到星期的中文名称
        /// <summary>
        /// 得到星期的中文名称
        /// </summary>
        /// <param name="p_strWeek">星期的英文名</param>
        /// <returns>星期的中文名称</returns>
        public static string GetWeekChineseName(string p_strWeek)
        {
            string strWeekName = "";

            switch (p_strWeek.ToLower())
            {
                case "monday":
                    strWeekName = "一";
                    break;
                case "tuesday":
                    strWeekName = "二";
                    break;
                case "wednesday":
                    strWeekName = "三";
                    break;
                case "thursday":
                    strWeekName = "四";
                    break;
                case "friday":
                    strWeekName = "五";
                    break;
                case "saturday":
                    strWeekName = "六";
                    break;
                case "sunday":
                    strWeekName = "日";
                    break;
                default:
                    return "";
            }

            strWeekName = "星期" + strWeekName;

            return strWeekName;
        }
        #endregion

        #region 获取一个XmlDocument示例文件
        /// <summary>
        /// 获取一个XmlDocument示例文件
        /// </summary>
        /// <returns></returns>
        public static XmlDocument getXmlDocModel()
        {
            XmlDocument xmlDoc = new XmlDocument();

            StringBuilder sbXmlDoc = new StringBuilder("");
            sbXmlDoc.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sbXmlDoc.Append("<RAD>");
            sbXmlDoc.Append("  <Doc>");
            sbXmlDoc.Append("       <Data />");
            sbXmlDoc.Append("       <Result>");
            sbXmlDoc.Append("           <ResCode>0</ResCode>");
            sbXmlDoc.Append("           <ResDetail />");
            sbXmlDoc.Append("       </Result>");
            sbXmlDoc.Append("   </Doc>");
            sbXmlDoc.Append("</RAD>");

            xmlDoc.LoadXml(sbXmlDoc.ToString());

            return xmlDoc;
        }
        #endregion

        #region 获取XmlDocument文件返回结果是否正确

        /// <summary>
        /// 获取XmlDocument文件返回结果是否正确
        /// </summary>
        /// <param name="p_xmlDoc">XmlDocument文件</param>
        /// <param name="p_strResultDetail">返回的详细信息</param>
        /// <returns>返回结果:0,正常;其他,异常</returns>
        public static string getXmlResult(XmlDocument p_xmlDoc, ref string p_strResultDetail)
        {
            string strCode = "0";
            try
            {
                strCode = SysFunction.getXmlResult(p_xmlDoc.SelectSingleNode("RAD/Doc/Result"), ref p_strResultDetail);
            }
            catch (Exception ex)
            {
                strCode = "1";
                p_strResultDetail = ex.Message;
                throw ex;
            }

            return strCode;
        }

        /// <summary>
        /// 获取XmlNode文件返回结果是否正确
        /// </summary>
        /// <param name="p_xnDoc">XmlNode文件</param>
        /// <param name="p_strResultDetail">返回的详细信息</param>
        /// <returns>返回结果:0,正常;其他,异常</returns>
        public static string getXmlResult(XmlNode p_xnDoc, ref string p_strResultDetail)
        {
            string strCode = "0";
            try
            {
                strCode = SysFunction.GetXmlNodeText(p_xnDoc, "ResCode");
                p_strResultDetail = SysFunction.GetXmlNodeText(p_xnDoc, "ResDetail");
            }
            catch (Exception ex)
            {
                strCode = "1";
                p_strResultDetail = ex.Message;
                throw ex;
            }

            return strCode;
        }

        #endregion

        #region 在XmlDocument文件的Result节点设置结果信息
        /// <summary>
        /// 在XmlDocument文件的Result节点设置结果信息
        /// </summary>
        /// <param name="p_strResCode">结果的编号</param>
        /// <param name="p_strResDetail">结果的详细信息</param>
        /// <returns>包含结果信息的XmlDocument标准文件</returns>
        public static XmlDocument getXmlDocWithResult(string p_strResCode, string p_strResDetail)
        {
            XmlDocument xmlResult = SysFunction.getXmlDocModel();
            xmlResult.SelectSingleNode("RAD/Doc/Result/ResCode").InnerText = p_strResCode;
            xmlResult.SelectSingleNode("RAD/Doc/Result/ResDetail").InnerText = p_strResDetail;

            return xmlResult;
        }
        #endregion

        #region 在XmlDocument文件的Result节点设置结果信息
        /// <summary>
        /// 在XmlDocument文件的Result节点设置结果信息
        /// </summary>
        /// <param name="p_strResCode">结果的编号</param>
        /// <param name="p_strResDetail">结果的详细信息</param>
        /// <returns>包含结果信息的XmlDocument标准文件</returns>
        public static XmlDocument getXmlDocWithResult(XmlDocument xmlResult, string p_strResCode, string p_strResDetail)
        {
            xmlResult.SelectSingleNode("RAD/Doc/Result/ResCode").InnerText = p_strResCode;
            xmlResult.SelectSingleNode("RAD/Doc/Result/ResDetail").InnerText = p_strResDetail;

            return xmlResult;
        }
        #endregion

        #region 添加XML子节点到传入的父节点中
        /// <summary>
        /// 添加XML子节点到传入的父节点中
        /// </summary>
        /// <param name="p_xnParent">XML父节点</param>
        /// <param name="p_xmlDoc">XML文档</param>
        /// <param name="p_strNodeName">子节点名称</param>
        /// <param name="p_strNodeValue">子节点文本</param>
        public static void AppendXmlNode(XmlNode p_xnParent, XmlDocument p_xmlDoc
            , string p_strNodeName, string p_strNodeValue)
        {
            XmlNode xnTemp;
            xnTemp = p_xmlDoc.CreateElement(p_strNodeName); //创建XML子节点
            xnTemp.InnerText = p_strNodeValue;//子节点显示的文本
            p_xnParent.AppendChild(xnTemp);//将子节点添加到父节点中
        }
        #endregion

        #region 得到XML节点的文本
        /// <summary>
        /// 得到XML节点的文本
        /// </summary>
        /// <param name="p_xnParent">父节点</param>
        /// <param name="p_strNodeName">节点名称</param>
        /// <returns>XML节点的文本</returns>
        public static string GetXmlNodeText(XmlNode p_xnParent, string p_strNodeName)
        {
            XmlNode xnChild = p_xnParent.SelectSingleNode(p_strNodeName);

            if (xnChild != null)//节点有数据
            {
                return xnChild.InnerText;
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 得到XML节点的属性值
        /// <summary>
        /// 得到XML节点的属性值
        /// </summary>
        /// <param name="p_xnParent">父节点</param>
        /// <param name="p_strNodeName">节点名称</param>
        /// <param name="p_strAttributeName">属性名称</param>
        /// <returns>XML节点的属性值</returns>
        public static string GetXmlNodeAttribute(XmlNode p_xnParent, string p_strNodeName, string p_strAttributeName)
        {
            //判断该节点是否存在该属性
            if (p_xnParent.SelectSingleNode(p_strNodeName + "[@name='" + p_strAttributeName + "']") != null)
            {
                return p_xnParent.SelectSingleNode(p_strNodeName).Attributes[p_strAttributeName].Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 得到XML节点的属性值
        /// </summary>
        /// <param name="p_xnNode">节点对象</param>
        /// <param name="p_strAttributeName">属性名称</param>
        /// <returns>XML节点的属性值</returns>
        public static string GetXmlNodeAttribute(XmlNode p_xnNode, string p_strAttributeName)
        {
            //判断该节点是否存在该属性
            if (p_xnNode.Attributes[p_strAttributeName] != null)
            {
                return p_xnNode.Attributes[p_strAttributeName].Value;
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 转换为XElement

        #region XmlElement转换为XElement

        /// <summary>   
        /// XmlElement转换为XElement   
        /// </summary>   
        public static XElement XmlElementToXElement(XmlElement xmlElement)
        {
            if (xmlElement == null)
            {
                return null;
            }

            XElement xElement = null;
            try
            {
                var doc = new XmlDocument();
                doc.AppendChild(doc.ImportNode(xmlElement, true));
                xElement = XElement.Parse(doc.InnerXml);
            }
            catch { }

            return xElement;
        }

        #endregion

        #region XmlNode转换为XElement

        /// <summary>
        /// XmlNode转换为XElement  
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static XElement XmlNodeToXElement(XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }

        #endregion

        #region xmlDoc转换为XElement

        /// <summary>
        /// xmlDoc转换为XElement  
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static XElement XmlDocumentToXElement(XmlDocument xmlDoc)
        {
            XElement xElement = XmlElementToXElement(xmlDoc.DocumentElement);
            return xElement;
        }

        #endregion

        #endregion

        #region XElement转换为XmlElement

        /// <summary>
        /// XElement转换为XmlElement
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns>XmlElement</returns>
        public static XmlElement XElementToXmlElement(XElement xElement)
        {
            if (xElement == null) return null;

            XmlElement xmlElement = null;
            XmlReader xmlReader = null;
            try
            {
                xmlReader = xElement.CreateReader();
                var doc = new XmlDocument();
                xmlElement = doc.ReadNode(xElement.CreateReader()) as XmlElement;
            }
            catch
            {
            }
            finally
            {
                if (xmlReader != null) xmlReader.Close();
            }

            return xmlElement;
        }

        #endregion

        #region XElement转换为XmlNode

        /// <summary>
        /// XElement转换为XmlNode
        /// </summary>
        /// <param name="element"></param>
        /// <returns>XmlNode</returns>
        public static XmlNode XElementToXmlNode(XElement element)
        {
            using (XmlReader xmlReader = element.CreateReader())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }

        #endregion

        #region XElement转换为XmlDocument

        /// <summary>
        /// XElement转换为XmlDocument
        /// </summary>
        /// <param name="element"></param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument XElementToXmlDocument(XElement element)
        {
            XmlElement xe = XElementToXmlElement(element);
            return XmlElementToXmlDocument(xe);
        }

        #endregion

        #region XmlDocument转换为XmlElement

        /// <summary>
        /// XmlDocument转换为XmlElement
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static XmlElement XmlDocumentToXmlElement(XmlDocument xmlDoc)
        {
            return xmlDoc.DocumentElement;
        }

        #endregion

        #region XmlElement转换为XmlDocument

        /// <summary>
        /// XmlElement转换为XmlDocument
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <returns></returns>
        public static XmlDocument XmlElementToXmlDocument(XmlElement xmlElement)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.ImportNode(xmlElement, true));
            return xmlDoc;
        }

        #endregion

        #region 数字转换成字母
        /// <summary>
        /// 数字转换成字母
        /// </summary>
        /// <param name="p_intNum">传入的数字</param>
        /// <returns>该数字对应的字母</returns>
        public static string NumberToLetter(int p_intNum)
        {
            string strLetter = "";
            char chrLetter = 'A';
            int intResult = (p_intNum - 1) / 26;//商
            int intResidual = (p_intNum - 1) % 26 + 1;//余数
            int intTempCode = (int)chrLetter;//'A'的ASCII码
            int intCode = 0;
            char chrTempLetter = 'A';

            if (intResult != 0)//传入的数字大于26
            {
                intCode = intTempCode + intResult - 1;
                chrTempLetter = (char)intCode;//将大于26的那部分数字转换成字母
                strLetter = chrTempLetter.ToString();
            }

            intCode = intTempCode + intResidual - 1;
            chrTempLetter = (char)intCode;//将数字转换成字母
            strLetter += chrTempLetter.ToString();

            return strLetter;
        }
        #endregion

        #region 得到文字宽度(限宋体)
        /// <summary>
        /// 得到文字宽度(限宋体)
        /// </summary>
        /// <param name="p_intFontSize">字体大小</param>
        /// <param name="p_strText">文字</param>
        /// <returns>文字宽度</returns>
        public static int GetTextWidth(int p_intFontSize, string p_strText)
        {
            int intLength = 0;
            int intTextWidth = 0;//文字宽度
            byte[] byteText = new byte[p_strText.Length];

            for (int i = 0; i < p_strText.Length; i++)
            {
                string strTemp = p_strText.Substring(i, 1);
                byteText = System.Text.Encoding.Default.GetBytes(strTemp);

                intLength = byteText.Length;

                if (intLength == 1)//半角英文或数字
                {
                    #region 半角英文或数字

                    switch (p_intFontSize)
                    {
                        case 10:
                            intTextWidth += 5;
                            break;
                        case 11:
                            intTextWidth += 6;
                            break;
                        case 12:
                            intTextWidth += 6;
                            break;
                        case 13:
                            intTextWidth += 7;
                            break;
                        default:
                            break;
                    }

                    #endregion
                }
                else if (intLength == 2)//全角中文
                {
                    #region 全角中文

                    switch (p_intFontSize)
                    {
                        case 10:
                            intTextWidth += 10;
                            break;
                        case 11:
                            intTextWidth += 11;
                            break;
                        case 12:
                            intTextWidth += 12;
                            break;
                        case 13:
                            intTextWidth += 13;
                            break;
                        default:
                            break;
                    }

                    #endregion
                }
            }

            return intTextWidth;
        }

        #endregion

        #region 得到水平对齐方式名称
        /// <summary>
        /// 得到水平对齐方式名称
        /// </summary>
        /// <param name="p_intAlignMode">水平对齐方式(1:左;2:中;3:右)</param>
        /// <returns>水平对齐方式名称</returns>
        public static string GetAlignMode(int p_intAlignMode)
        {
            string strAlignMode = "";//水平对齐方式名称

            switch (p_intAlignMode)
            {
                case 1:
                    strAlignMode = "left";
                    break;
                case 2:
                    strAlignMode = "center";
                    break;
                case 3:
                    strAlignMode = "right";
                    break;
                default:
                    strAlignMode = "center";
                    break;
            }

            return strAlignMode;
        }
        #endregion

        #region 得到垂直对齐方式名称
        /// <summary>
        /// 得到垂直对齐方式名称
        /// </summary>
        /// <param name="p_intVAlignMode">垂直对齐方式(1:顶;2:中;3:底)</param>
        /// <returns>垂直对齐方式名称</returns>
        public static string GetVAlignMode(int p_intVAlignMode)
        {
            string strVAlignMode = "";//垂直对齐方式名称

            switch (p_intVAlignMode)
            {
                case 1:
                    strVAlignMode = "top";
                    break;
                case 2:
                    strVAlignMode = "middle";
                    break;
                case 3:
                    strVAlignMode = "bottom";
                    break;
                default:
                    strVAlignMode = "middle";
                    break;
            }

            return strVAlignMode;
        }
        #endregion

        #region 得到配置文件中的值
        /// <summary>
        /// 得到配置文件中的值
        /// </summary>
        /// <param name="p_strKey">配置文件中的键</param>
        /// <returns>配置文件中的值</returns>
        public static string GetConfigValue(string p_strKey)
        {
            string strConfigValue = "";
            try
            {
                strConfigValue = ConfigurationSettings.AppSettings[p_strKey].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strConfigValue;
        }
        #endregion

        #region 根据指定的对象类型，创建该类型的实例。
        /// <summary>
        /// 根据指定的对象类型，创建该类型的实例。
        /// </summary>
        /// <param name="type">指定的对象类型</param>
        /// <param name="args">要传递给构造函数的参数。</param>
        /// <returns>指定的对象类型的实例</returns>
        public static object CreateInstance(Type type, object[] args)
        {
            object obj = null;
            try
            {
                Assembly assembly = type.Assembly;
                string typeName = type.FullName;
                BindingFlags flags = BindingFlags.CreateInstance;
                CultureInfo culture = CultureInfo.CurrentCulture;

                obj = assembly.CreateInstance(typeName, false, flags, null, args, culture, null);
            }
            catch
            {
            }

            return obj;
        }
        #endregion

        #region 根据类型名称，获取其对应的类型
        /// <summary>
        /// 根据类型名称，获取其对应的类型
        /// </summary>
        /// <param name="typeName">类型名称(全名)。</param>
        /// <returns>类型</returns>
        public static Type GetType(string typeName)
        {
            Type type = null;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = assembly.GetType(typeName);
                if (type != null)
                {
                    break;
                }
            }

            return type;
        }
        #endregion

        #region 获取指定对象的指定方法的执行结果
        /// <summary>
        /// 获取指定对象的指定方法的执行结果。
        /// </summary>
        /// <param name="obj">指定对象</param>
        /// <param name="strMethodName">指定方法的名称</param>
        /// <param name="args">要传递给指定方法的参数。</param>
        /// <returns>执行结果</returns>
        public static object GetMethodResult(object obj, string strMethodName, object[] args)
        {
            try
            {
                BindingFlags flags = BindingFlags.InvokeMethod;
                return obj.GetType().InvokeMember(strMethodName, flags, null, obj, args);
            }
            catch
            {
            }
            return "";
        }
        #endregion

        #region 获取某对象的某属性的值
        /// <summary>
        /// 获取某对象的某属性的值
        /// </summary>
        /// <param name="obj">某对象</param>
        /// <param name="propName">某属性名</param>
        /// <returns>某属性的值</returns>
        public static object GetProperty(object obj, string propName)
        {
            try
            {
                BindingFlags flags = BindingFlags.GetProperty;
                //return obj.GetType().InvokeMember(propName, flags, null, obj, null);
                obj.GetType().InvokeMember(propName, flags, null, obj, null);

                return obj;
            }
            catch
            {
            }

            return null;
        }
        #endregion

        #region 获取某对象的某属性的类型
        /// <summary>
        /// 获取某对象的某属性的类型
        /// </summary>
        /// <param name="obj">某对象</param>
        /// <param name="propName">某属性名</param>
        /// <returns>某属性的类型</returns>
        public static Type GetPropetyType(object obj, string propName)
        {
            try
            {
                BindingFlags flags = BindingFlags.GetProperty;
                PropertyInfo info = obj.GetType().GetProperty(propName, flags);
                return info.PropertyType;
            }
            catch
            {
            }

            return null;
        }
        #endregion

        #region 给某对象的某属性赋值
        /// <summary>
        /// 给某对象的某属性赋值
        /// </summary>
        /// <param name="obj">某对象</param>
        /// <param name="propName">某属性名</param>
        /// <param name="strValue">值</param>
        /// <returns>某对象</returns>
        public static object SetProperty(object obj, string propName, string strValue)
        {
            try
            {
                BindingFlags flags = BindingFlags.SetProperty;
                obj.GetType().InvokeMember(propName, flags, null, obj, new object[] { strValue });
                return obj;
            }
            catch
            {
            }

            return null;
        }
        #endregion

        #region 根据指定的对象，在指定xml存储路径 生成 相应的xml文件
        /// <summary>
        /// 根据指定的对象，在指定xml存储路径 生成 相应的xml文件
        /// </summary>
        /// <param name="obj">待转换的对象</param>
        /// <param name="strPath">指定xml存储路径</param>
        public static void WriteXML(object obj, string strPath)
        {
            TextWriter writer = null;
            try
            {
                // 直接序列化生成xml
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                writer = new StreamWriter(strPath);

                serializer.Serialize(writer, obj);
                writer.Close();
            }
            catch (Exception err)
            {
                if (writer != null)
                    writer.Close();

                throw err;
            }
        }
        #endregion

        #region 从指定路径的xml文件，生成 相对应的指定对象
        /// <summary>
        /// 从指定路径的xml文件，生成 相对应的指定对象
        /// </summary>
        /// <param name="strPath">指定路径</param>
        /// <param name="objType">待生成对象的类型</param>
        /// <returns>指定类型的实例对象</returns>
        public static object ReadXML(string strPath, Type objType)
        {
            object obj = null;
            TextReader reader = null;
            try
            {
                // 判断文件是否存在
                if (File.Exists(strPath))
                {
                    reader = new StreamReader(strPath, Encoding.UTF8);

                    XmlSerializer serializer = new XmlSerializer(objType);
                    //serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
                    //serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
                    obj = serializer.Deserialize(reader);

                    reader.Close();
                }
            }
            catch (Exception err)
            {
                if (reader != null)
                    reader.Close();

                throw err;
            }

            return obj;
        }
        #endregion

        #region XML序列化、反序列化私有方法

        private static void DumpException(Exception ex)
        {
            //Console.WriteLine("--------- Outer Exception Data ---------");        
            WriteExceptionInfo(ex);
            ex = ex.InnerException;
            if (null != ex)
            {
                //Console.WriteLine("--------- Inner Exception Data ---------");                
                WriteExceptionInfo(ex.InnerException);
                ex = ex.InnerException;
            }
        }

        private static void WriteExceptionInfo(Exception ex)
        {
            string e1 = ex.Message;
            string e2 = ex.GetType().FullName;
            string e3 = ex.Source;
            string e4 = ex.StackTrace;
            string e5 = ex.TargetSite.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            //string s = "Unknown Node:" + e.Name + "\t" + e.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            //XmlAttribute attr = e.Attr;
            //string s = "Unknown Node:" + attr.Name + "\t" + attr.Value;
        }

        #endregion

        private const string FS_RANDOM_STRING = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

        #region 取随机数的私有方法
        /// <summary>
        /// 得到长度为length的随机字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns>长度为length的随机字符串</returns>
        public static string FsRandomString(int length)
        {
            try
            {
                string res = "";
                for (int i = 0; i < length; i++)
                {
                    int s1 = FsRandom(0, 44);
                    res += FS_RANDOM_STRING.Substring(s1, 1);
                }
                return res;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region FsRandom 随机数
        /// <summary>
        ///  FsRandom 随机数
        /// </summary>
        /// <param name="MinInt">最小值，包含</param>
        /// <param name="MaxInt">最大值，包含</param>
        /// <returns>FsRandom 随机数</returns>
        public static int FsRandom(int MinInt, int MaxInt)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks) + FsRandomS(100000));
            return rnd.Next(MinInt, MaxInt);
        }

        /// <summary>
        ///  FsRandom 随机数
        /// </summary>
        /// <param name="MaxInt">最大值，包含</param>
        /// <returns>FsRandom 随机数</returns>
        private static int FsRandomS(int MaxInt)
        {
            Random rnd = new Random(new System.Globalization.GregorianCalendar().GetHashCode());
            return rnd.Next(0, MaxInt);
        }
        #endregion

        #region 动态调用DLL
        /// <summary>
        /// 动态调用DLL
        /// </summary>
        /// <param name="url">dll路径</param>
        /// <param name="className">要调用的类名,从最顶层的命名空间写到类名</param>
        /// <param name="methodName">要调用的方法名</param>
        /// <param name="args">参数的集合</param>
        /// <returns>所调用的方法的返回值</returns>
        public static object InvokeDLL(string url, string className, string methodName, object[] args)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(url);
                Type type = assembly.GetType(className);
                MethodInfo methodInfo = type.GetMethod(methodName);
                Object obj = System.Activator.CreateInstance(type);

                return methodInfo.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }
        #endregion

        #region 动态调用web服务:InvokeWebService
        /// <summary>
        /// 动态调用web服务
        /// </summary>
        /// <param name="url">Web服务url</param>
        /// <param name="methodname">Web服务方法名</param>
        /// <param name="args">Web服务方法参数</param>
        /// <returns></returns>
        public static object InvokeWebService(string url, string methodname, object[] args)
        {
            return SysFunction.InvokeWebService(url, null, methodname, args);
        }

        /// <summary>
        /// 动态调用web服务
        /// </summary>
        /// <param name="url">Web服务url</param>
        /// <param name="classname">Web服务类名</param>
        /// <param name="methodname">Web服务方法名</param>
        /// <param name="args">Web服务方法参数</param>
        /// <returns></returns>
        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            string @namespace = "WebService.DynamicWebCalling";
            if ((classname == null) || (classname == ""))
            {
                classname = SysFunction.GetWsClassName(url);
            }

            try
            {
                //获取WSDL
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);

                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);

                //设定编译参数
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类
                CSharpCodeProvider csc = new CSharpCodeProvider();
                //ICodeCompiler icc = csc.CreateCompiler();//已经过时
                CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }

                //生成代理实例，并调用方法
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodname);
                if (args != null)
                {
                    return mi.Invoke(obj, args);
                }
                else
                {
                    return mi.Invoke(obj, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }

        /// <summary>
        /// 获取Web服务的类名
        /// </summary>
        /// <param name="wsUrl"></param>
        /// <returns></returns>
        private static string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
        #endregion

        #region 获取数据库的系统当前时间
        /// <summary>
        /// 获取数据库的系统当前时间
        /// </summary>
        /// <returns>当前时间的字符串</returns>
        public static string GetDBCurrentTime()
        {
            string dateTime = "";
            dateTime = "TO_DATE('" + DateTime.Now + "','yyyy-MM-dd HH24:mi:ss')";
            return dateTime;
        }
        #endregion

        #region 全局变量相关
        /// <summary>
        /// Gets the current context.
        /// </summary>
        /// <value>The current context.</value>
        public static HttpContext Context
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    throw new Exception("The current httpcontext is null");
                }
                return context;
            }
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="Path">string Path：文件夹路径</param>
        /// <returns></returns>
        public static bool CreateDir(string Path)
        {
            try
            {//判断文件夹是否存在
                if (Directory.Exists(Path) == false)
                {
                    Directory.CreateDirectory(Path);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 将字符串写入指定文件

        /// <summary>
        /// 将字符串写入指定文件
        /// </summary>
        /// <param name="filePath">文件路径（包括文件名）</param>
        /// <param name="strConent">字符串内容</param>
        /// <returns></returns>
        public static bool StringWriteToFile(string filePath, string strConent)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    StreamWriter sw = File.AppendText(filePath);
                    sw.WriteLine(strConent);
                    sw.Close();       //关闭流
                    sw.Dispose();    //销假对象
                }
                else
                {
                    StreamWriter sw = File.CreateText(filePath);
                    sw.WriteLine(strConent);
                    sw.Close();
                    sw.Dispose();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 读取文件文本

        /// <summary>
        /// 读取文件文本(应用场景1：获取HTML前台代码)
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <returns>文件文本</returns>
        public static string GetFileString(string strFilePath)
        {
            StringBuilder fileText = new StringBuilder();
            try
            {
                using (StreamReader streamReader = new StreamReader(strFilePath, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    string line = "";
                    line = streamReader.ReadToEnd();
                    fileText.Append(line);
                    streamReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fileText.ToString();
        }

        #endregion

        #region 序列化

        /// <summary> 
        /// 序列化 
        /// </summary> 
        /// <param name="data">要序列化的对象</param> 
        /// <returns>返回存放序列化后的数据缓冲区</returns> 
        public static byte[] Serialize(object data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream rems = new MemoryStream();
            formatter.Serialize(rems, data);
            return rems.GetBuffer();
        }

        #endregion

        #region 反序列化

        /// <summary> 
        /// 反序列化 
        /// </summary> 
        /// <param name="data">数据缓冲区</param> 
        /// <returns>对象</returns> 
        public static object Deserialize(byte[] data)
        {
            object resultObj = null;
            if (data != null && data.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream rems = new MemoryStream(data);
                resultObj = formatter.Deserialize(rems);
            }
            return resultObj;
        }

        #endregion

        #region HTML特殊字符转换

        /// <summary>
        /// HTMLs the en code.
        /// </summary>
        /// <param name="sHTML">The HTML.</param>
        /// <returns></returns>
        public static string HTMLEnCode(string sHTML)
        {
            string sTemp = "";
            if (sHTML.Length == 0)
            {
                return "";
            }
            sTemp = sTemp.Replace("&", "&amp;");
            sTemp = sHTML.Replace("<", "&lt;");
            sTemp = sTemp.Replace(">", "&gt;");
            sTemp = sTemp.Replace("'", "&#39;");
            sTemp = sTemp.Replace(" ", "&nbsp;");
            sTemp = sTemp.Replace("\"", "&quot;");
            sTemp = sTemp.Replace("\n", "<br />");
            return sTemp;
        }

        /// <summary>
        /// HTMLs the de code.
        /// </summary>
        /// <param name="sHTML">The HTML.</param>
        /// <returns></returns>
        public static string HTMLDeCode(string sHTML)
        {
            string sTemp = "";
            if (sHTML.Length == 0)
            {
                return "";
            }
            sTemp = sHTML.Replace("&lt;", "<");
            sTemp = sTemp.Replace("&gt;", ">");
            sTemp = sTemp.Replace("&#39;", "'");
            sTemp = sTemp.Replace("&nbsp;", " ");
            sTemp = sTemp.Replace("&quot;", "\"");
            sTemp = sTemp.Replace("<br />", "\n");
            sTemp = sTemp.Replace("&amp;", "&");
            return sTemp;
        }

        #endregion

        #region 取得网站的根目录的URL,包括虚拟目录

        /// <summary>
        /// 取得网站的根目录的URL,包括虚拟目录
        /// </summary>
        /// <returns>如：https：//www.do.com/apppath </returns>
        public static string GetRootURI(string webPort)
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;

                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    //直接安装在Web站点   
                    AppPath = UrlAuthority + webPort;
                else
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + webPort + Req.ApplicationPath;
            }
            return AppPath;
        }

        #endregion

        #region 判断字符串是否为Guid格式

        /// <summary>
        /// 判断字符串是否为Guid格式 Guid的TryParse/Parse方法(.Net 4.0才新增加的)
        /// </summary>
        /// <param name="strSrc"></param>
        /// <returns></returns>
        public static bool IsGuidByParse(string strSrc)
        {
            Guid g = Guid.Empty;
            return Guid.TryParse(strSrc, out g);
        }

        #endregion

        #region 判断一个字符串是否为json格式 

        /// <summary>
        /// 判断一个字符串是否为json格式  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        } 
        
        #endregion


        #endregion

    }
}