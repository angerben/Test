using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;

namespace Participle
{
    class Program
    {

        private string strIndexPath = string.Empty;
        protected string txtTitle = string.Empty;
        protected string txtContent = string.Empty;
        protected long lSearchTime = 0;
        protected string txtPageFoot = string.Empty;
        static void Main(string[] args)
        {
            //定义盘古分词的xml引用路径
            PanGu.Segment.Init(PanGuXmlPath);
            AddIndex(writer, "我的标题" + i, i + "标题内容是飞大师傅是地方十大飞啊的飞是 安抚爱上地方 爱上地方" + i, DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));
            AddIndex(writer, "射雕英雄传作者金庸" + i, i + "我是欧阳锋" + i, DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));
            AddIndex(writer, "天龙八部2" + i, i + "慕容废墟,上官静儿,打撒飞艾丝凡爱上,虚竹" + i, DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));
            AddIndex(writer, "倚天屠龙记2" + i, i + "张无忌机" + i, DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));
            AddIndex(writer, "三国演义" + i, i + "刘备,张飞,关羽" + i, DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// 索引存放目录
        /// </summary>
        static string IndexDic
        {
            get
            {
                return "/IndexDic";
            }
        }

        /// <summary>
        /// 盘古分词的配置文件
        /// </summary>
        static string PanGuXmlPath
        {
            get
            {
                return "/PanGu/PanGu.xml";
            }
        }

        /// <summary>
        /// 盘古分词器
        /// </summary>
        static Analyzer PanGuAnalyzer
        {
            get { return new PanGuAnalyzer(); }
        }

        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="analyzer"></param>
        /// <param name="content"></param>
        static void AddIndex(IndexWriter writer, string title, string content, string date)
        {
            try
            {
                Document doc = new Document();
                doc.Add(new Field("Title", title, Field.Store.YES, Field.Index.NOT_ANALYZED));//存储且索引
                doc.Add(new Field("Content", content, Field.Store.YES, Field.Index.ANALYZED));//存储且索引
                doc.Add(new Field("AddTime", date, Field.Store.YES, Field.Index.NOT_ANALYZED));//存储且索引
                writer.AddDocument(doc);
            }
            catch (FileNotFoundException fnfe)
            {
                throw fnfe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
