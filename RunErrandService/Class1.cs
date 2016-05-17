using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RunErrandService
{
    public class Class1
    {
        

        //public class LatitudeUtils {
 
        // public static final String KEY_1 = "327db7009617d6806b9c38e819ea06ac"; 
        // /**
        //  * 返回输入地址的经纬度坐标
        //  * key lng(经度),lat(纬度)
        //  */
        // public static Map<String,String> getLatitude(String address){
        //  try {
        ////  将地址转换成utf-8的16进制
        //     address = URLEncoder.encode(address, "UTF-8");
        ////  如果有代理，要设置代理，没代理可注释
        ////  System.setProperty("http.proxyHost","192.168.172.23");
        ////  System.setProperty("http.proxyPort","3209");
        //   URL resjson = new URL("http://api.map.baidu.com/geocoder?address="
        //                      + address +"&output=json&key="+ KEY_1);
  
        //   BufferedReader in = new BufferedReader(
        //                      new InputStreamReader(resjson.openStream()));
        //   String res;
        //   StringBuilder sb = new StringBuilder("");
        //   while((res = in.readLine())!=null){
        //    sb.append(res.trim());
        //   }
        //   in.close();
        //   String str = sb.toString();
        //   System.out.println("return json:"+str);
        //   Map<String,String> map = null;
        //   if(StringUtils.validNull(str)){
        //    int lngStart = str.indexOf("lng\":");
        //    int lngEnd = str.indexOf(",\"lat");
        //    int latEnd = str.indexOf("},\"precise");
        //    if(lngStart > 0 && lngEnd > 0 && latEnd > 0){
        //     String lng = str.substring(lngStart+5, lngEnd);
        //     String lat = str.substring(lngEnd+7, latEnd);
        //     map = new HashMap<String,String>();
        //     map.put("lng", lng);
        //     map.put("lat", lat);
        //     return map;
        //    }
        //   }
        //  }catch (Exception e) {
        //   e.printStackTrace();
        //  }
        //  return null;
        // }
        // public static void main(String args[]){
        //  Map<String,String> map = LatitudeUtils.getLatitude("北京西城区北京北站");
        //    if(null != map){
        //       System.out.println(map.get("lng"));
        //       System.out.println(map.get("lat"));
        //    }
        // }
        //}
    }
}