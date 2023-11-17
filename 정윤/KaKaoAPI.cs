using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace C_TeamProject
{
    // REST API 정보 불러오는 것 
public class KaKaoAPI
    {
        public static List<Locale> Search(string text)
        {
            List<Locale> list = new List<Locale>(); // 지역정보들 불러옴
            string url = "https://dapi.kakao.com/v2/local/search/keyword.json";
            string query = $"{url}?query={text}";
            string restAPIKey = "2f23516a0b28443cfc35d2893103b6f7";
            string Header = $"KakaoAK {restAPIKey}";
            WebRequest request = WebRequest.Create(query); // 요청받은 정보들을 리스트에 쭉 담아서 같이 볼거임
            request.Headers.Add("Authorization", Header);

            //  응답 받기
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string json = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
           

            // dynamic : var랑 좀 다르게 선언한 뒤에도 자료형을 자유롭게 바꿀 수 있음
            dynamic ex = "백정윤";  // 처음 정해진 타입이 나중에 바뀔 수 있음 
            ex = 999;
            var ex2 = "백정윤"; // 한 번 정한 타입이 끝까지 감
            // ex2 = 999;
            dynamic dob = js.Deserialize<dynamic>(json);
            dynamic docs = dob["documents"];
            object[] buf = docs;
            int length = buf.Length;
            for(int i = 0; i<length; i++)
            {
                string Iname = docs[i]["place_name"];
                double x = double.Parse(docs[i]["x"]);
                double y = double.Parse(docs[i]["y"]);
                list.Add(new Locale(Iname, y, x));  // 지도에 마커를 띄울 거임 
            }

            return list;
        }
       
    }
}
