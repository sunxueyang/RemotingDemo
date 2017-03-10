using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebRemotingServer;

namespace WebRemotingClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        /*
         * web应用 客户端
         * 
         * 调用的服务端必须挂载在IIS或者windows服务启动项中
         */



        WebRemotingServer.IMyInterface client_server;
        const string OBJECT_URL = "MyServer.rem";
        const string REMOTING_URL = "http://127.0.0.1:9011/";
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUri = REMOTING_URL + OBJECT_URL;
            if (ChannelServices.GetChannel("DataProClient") == null)
            {
                ListDictionary channelProperties = new ListDictionary();
                channelProperties.Add("port", 0);
                channelProperties.Add("name", "DataProClient");
                channelProperties.Add("timeout", -1);
                channelProperties.Add("proxyName", "");

                BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
                provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                HttpChannel channel = new HttpChannel(channelProperties, new BinaryClientFormatterSinkProvider(), provider);
                ChannelServices.RegisterChannel(channel, false);
            }
            client_server = (WebRemotingServer.IMyInterface)RemotingServices.Connect(typeof(WebRemotingServer.IMyInterface), strUri);

        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = say(TextBox1.Text);
        }

        public string say(string name)
        {
            string word = client_server.sayHello(name);
            return word;
        }
    }
}