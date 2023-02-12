using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using TvorchestvoProgram.Context;
using TvorchestvoProgram.Model;
using WebServerTvor.ApiModel;

namespace WebServerTvor
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:12652/");

            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            server.Start();
            while (true)
            {
                HttpListenerContext context = server.GetContext();
                /// API метод Get
                if (context.Request.HttpMethod == "GET")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/products/")
                        {
                            var productList = Data.u01.Product.ToList();
                            string response = System.Text.Json.JsonSerializer.Serialize(Data.u01.Product.ToList().ConvertAll(c => new Response(c)), options);
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            context.Response.ContentType = "application/json;charset=utf-8";
                            using (Stream stream = context.Response.OutputStream)
                            {
                                context.Response.StatusCode = 200;
                                stream.Write(data, 0, data.Length);
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }               
                /// API метод Post
                else if (context.Request.HttpMethod == "POST")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/products/")
                        {
                            if (context.Request.ContentType == "application/json")
                            {
                                string request = "";
                                byte[] data = new byte[context.Request.ContentLength64];
                                using (Stream stream = context.Request.InputStream)
                                {
                                    stream.Read(data, 0, data.Length);
                                }
                                request = UTF8Encoding.UTF8.GetString(data);
                                var productList = System.Text.Json.JsonSerializer.Deserialize<List<Response>>(request);
                                foreach (var item in productList)
                                {
                                    Product objects = new Product();
                                    objects.ProductArticleNumber = item.ProductArticleNumber;
                                    objects.ProductName = item.ProductName;
                                    objects.ProductDescription = item.ProductDescription;
                                    objects.IDProductCategory = item.IDProductCategory;
                                    objects.Image = item.Image;
                                    objects.ProductCost = item.ProductCost;
                                    objects.ProductDiscountAmount = item.ProductDiscountAmount;
                                    objects.IDProductCategory = item.IDProductCategory;
                                    objects.ProductQuantityInStock = item.ProductQuantityInStock;
                                    objects.ProductUnit = item.ProductUnit;
                                    objects.Supplier = item.Supplier;
                                    Data.u01.Product.Add(objects);
                                }
                                Data.u01.SaveChanges();
                                context.Response.StatusCode = 200;
                                context.Response.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();

                    }
                }
            }
        }
    }
}
