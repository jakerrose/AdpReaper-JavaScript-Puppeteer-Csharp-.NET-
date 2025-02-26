using CsvHelper;
using Lifewell_Reaper.Classes;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Web;
using System.Threading;
using System.Collections.Specialized;
using System.Security.Policy;
//using System.Web.Routing;

using System.Drawing;
using Org.BouncyCastle.Crypto.Engines;
using PuppeteerSharp.Media;
using Org.BouncyCastle.Crypto.Generators;
using iTextSharp.text.pdf;
//using System.Web.UI.WebControls;
using System.Reflection.Emit;
using iTextSharp.text;
using System.Xml.Linq;
using System.Windows;
using System.Text.RegularExpressions;
using PuppeteerSharp.Input;
using System.Net.Http;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

using System.Net;
using iTextSharp.text.pdf.qrcode;

using Aspose.Cells;
using Org.BouncyCastle.Asn1.Ocsp;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Engineering;
//using System.Web.UI;
using Paycom_Uploader;
using Org.BouncyCastle.Ocsp;
using Lifewell;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography;
using TryItADP;
using iTextSharp.text.pdf.parser;
using OfficeOpenXml.SystemDrawing.Text;
using System.Printing;
using SelectPdf;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mesa 

{
	internal class Program
	{

		//Test Comment for test Commit
		private static bool runHeadless = false;

		//used to access the settings in App.config
		private static NameValueCollection reaperSettings;

		//values come from App.config
		private static string baseDir;
		private static string browserPort;
		private static string browserProfileName;
		private static string outputDir;
		private static string outputDirLF;


		private static string loginUrl = "https://online.adp.com/signin/v1/?APPID=WFNPortal&productId=80e309c3-7085-bae1-e053-3505430b5495&returnURL=https://workforcenow.adp.com/&callingAppId=WFN&TARGET=-SM-https://workforcenow.adp.com/theme/index.html";



		//company login name      
		private static string companyLogin;
		private static string userName;

		private static string password;


		private static Browser browser; //test again for bitbucket
										//private static IBrowser browser;

		private static List<PaychexEmp> paychexEmps = new List<PaychexEmp>();
		//private static PaycorEmployeesJson paycorEmps = new PaycorEmployeesJson();
		private static List<PaycomEmpData> PaycomEmps = new List<PaycomEmpData>();
		private static List<EmployeeRecordADP> Emp = new List<EmployeeRecordADP>();
		private static List<CrosswalkEmp> CrosswalkEmps = new List<CrosswalkEmp>();
		private static List<CrosswalkRoot> FullCrossWalkEmps = new List<CrosswalkRoot>();



		static void Main(string[] args)
		{

			Run();
			Console.ReadLine();
		}


		public static string RIC(string filename)
		{
			if (filename == null)
				return ("null");

			var sTmp = filename.Replace(".", "").Replace("'", "").Replace(",", "").Replace("_", "-");
			return string.Join("-", sTmp.Split(System.IO.Path.GetInvalidFileNameChars()));
		}


		static async void Run()
		{
			//var httpClient = new HttpClient();
			//HttpResponseMessage response = await httpClient.GetAsync(loginUrl);
			//IEnumerable<string> cookies = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;

			reaperSettings = ConfigurationManager.GetSection("ReaperSettings") as NameValueCollection;
			if (reaperSettings != null)
			{
				browserPort = reaperSettings["BrowserPort"].ToString();
				browserProfileName = reaperSettings["BrowserProfileName"].ToString();
				baseDir = reaperSettings["BaseDirectory"].ToString();
				companyLogin = reaperSettings["Company"].ToString();
				userName = reaperSettings["UserName"].ToString();
				password = reaperSettings["Password"].ToString();

			}

			outputDir = baseDir + "\\Company Output";

			if (!Directory.Exists(outputDir))
				Directory.CreateDirectory(outputDir);

			outputDirLF = System.IO.Path.Combine(outputDir, "Necessary List Files Lifewell");

			if (!Directory.Exists(outputDir))
				Directory.CreateDirectory(outputDir);

			////var result = await GetBrowser();
			//page = await browser.NewPageAsync();
			//await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36");
			//await page.SetUserAgentAsync("Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:109.0) Gecko/20100101 Firefox/117.0");
			////await page.SetViewportAsync(new ViewPortOptions
			////{
			////    Width = 0,
			////    Height = 0,
			////});
			//if (result) await Login();

			var resultB = await GetBrowser();
			if (resultB)
			{
				////await LoginAsync(loginUrl, userName, password);
				await Login();
				//await LoginADPeet2();
				//await LoginADPTimeAttendGateway();
			}

			////GetDateRangesFromCsv();	//Gotta have this for ADP Timecard extraction . . .

			var navigation = new NavigationOptions
			{
				Timeout = 0,
				WaitUntil = new[] { WaitUntilNavigation.Networkidle2 }
			};

			var page = (await browser.PagesAsync()).First();
			page.DefaultTimeout = 60000;
			page.DefaultNavigationTimeout = 60000;

			////var exportPath = Path.Combine(outputDir, $"CS{company}");



			var fileName = "";
			var filePath = "";
			var fetch = "";


			var iStart = 0;
			var keyMove = iStart;


			//await GetEmployeeSummaryMetadata();
			//await ExportEmps();
			//ConvertXlsxToJson();
			//LoadEmps();
			//LoadPosEmps();

			try
			{
				//await employeeFetch();
				
				await GetLMSPdf();
				//await renameLMSPdf();
				
				//await JsonToHtml();
				//await PayHistoryHtml();
				//await getPositionHistoryHTML();
				//await getEnrollmentHistory();

				//await getI9emps();
				//await getI9info();
				//await renameI9();

				//await renameW2C();
				//await renameW2();
				//await compareJsonPdf();
				//await renameId();
				//await renamePdf();
				//await HtmlToPdf();
				//await redoCorruptFiles();
				//await renameEmployeeProfiles();
				//await rename1095c();
				//await compare1095C();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

				//restart and try again
				await browser.CloseAsync();

				Run();
			}
		}
		//Used to check if names of files match i.e. after a conversion when there are files missing
		static async Task compare1095C()
		{
			try
			{
				var Folder1 = @"C:\Temp\Testing\GenericCompany\I9ScreenshotsServer5T-W";
				var Folder2 = @"C:\Temp\Testing\GenericCompany\I9Pdf\new";

				List<string> list1 = new List<string>();
				List<string> list2 = new List<string>();

				string[] files1 = Directory.GetFiles(Folder1);
					foreach (var file1 in files1)
				{
					string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file1);
					//Console.WriteLine(fileNameWithoutExtension);
					//string[] parts = fileNameWithoutExtension.Split('_');

					//var ssn = parts[3];
					//string[] ssnParts = ssn.Split("-");
					//var lastFour = ssnParts[2];

					//list1.Add(lastFour);		
					list1.Add(fileNameWithoutExtension);		
				}
				string[] files2 = Directory.GetFiles(Folder2);
				foreach (var file2 in files2)
				{
					string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file2);
					//Console.WriteLine(fileNameWithoutExtension);
					//string[] parts = fileNameWithoutExtension.Split('_');

					//var lastFour = parts[5];
					//list2.Add(lastFour);
					list2.Add(fileNameWithoutExtension);
				}

				// Convert lists to sets for easier comparison
				HashSet<string> set1 = new HashSet<string>(list1);
				HashSet<string> set2 = new HashSet<string>(list2);

				// Find values missing in list2
				var missingInList2 = set1.Except(set2).ToList();
				var missingInList1 = set2.Except(set1).ToList();
				//if (missingInList2.Any())
				//{
				//	Console.WriteLine("Values in Folder1 but missing in Folder2:");
				//	foreach (var value in missingInList2)
				//	{
				//		Console.WriteLine(value);
				//	}
				//}
				if (missingInList1.Any())
				{
					Console.WriteLine("Files in Folder2 but missing in Folder1:");
					foreach (var value in missingInList1)
					{
						Console.WriteLine(value);
					}
				}

				//if (!missingInList2.Any() && !missingInList1.Any())
				//{
				//	Console.WriteLine("No missing files between Folder1 and Folder2.");
				//}
				else
				{
					Console.WriteLine("No missing values in Folder2.");
				}

			}
			catch (Exception e)
			{ Console.WriteLine(e.Message); }
		}

		//To be used after splitting documents with Adobe Acrobat
		static async Task rename1095c()
		{
			try
			{
				string inputDirectory = @"C:\Users\rosej\OneDrive\Documents\NinePeaks\GenericCompany\1095Split\ZYH";
				string outputDirectory = @"C:\Users\rosej\OneDrive\Documents\NinePeaks\GenericCompany\1095_renamed\ZYH";

				string[] files = Directory.GetFiles(inputDirectory);

				foreach (string file in files)
				{
					Console.WriteLine(System.IO.Path.GetFileName(file));
					// Extract filename without extension
					string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);
					Console.WriteLine(fileNameWithoutExtension);
					string fileName = System.IO.Path.GetFileName(file);

					string[] parts = fileNameWithoutExtension.Split('_');

					if (parts.Length == 4)
					{
						var coCode = parts[0];
						var year = parts[2];
						if (year == "23")
						{
							year = "2023";
						}
						else if (year == "22")
						{
							year = "2022";
						}
						var ssn = parts[3];
						string[] ssnParts = ssn.Split('-');
						var lastFour = ssnParts[2];
						lastFour = lastFour.Trim();

						var name = parts[1];
						name = RemoveSingleLetters(name);
						string[] nameParts = name.Split(" ");

						if (nameParts.Length == 2)
						{
							var lastName = nameParts[1];
							var firstName = nameParts[0];
							Console.WriteLine("new name: " + firstName + " " + lastName);
							EmployeeRecordADP matchedemp = null;
							bool found = false;

							foreach (var emp in Emp)
							{
								// Check if emp.uniqueID is not null
								if (emp.uniqueID != null && emp.uniqueIdTypeCode == "SSN")
								{
									// Check if emp.positions[0].coCode is not null
									if (emp.positions[0].coCode != null)
									{
										var empSsn = emp.uniqueID;
										string[] empSsnParts = empSsn.Split('-');
										var empLastFour = empSsnParts[2];
										if (coCode == emp.positions[0].coCode && lastFour == empLastFour && string.Equals(lastName.Substring(0, 3), emp.lastName.Substring(0, 3), StringComparison.OrdinalIgnoreCase)
											&& string.Equals(firstName.Substring(0, 3), emp.firstName.Substring(0, 3), StringComparison.OrdinalIgnoreCase))
										{
											matchedemp = emp;
											found = true;
											break; // Stop the loop if a match is found
										}
									}
								}
							}
							if (found == true && matchedemp != null)
							{
								var empId = "";
								if (matchedemp.positions[0].fileNumber != null)
									empId = matchedemp.positions[0].fileNumber;
								else empId = "000000";
								CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedemp.positions[0].fileNumber);
								var paycomId = "";
								if (paycomPerson != null)
									paycomId = paycomPerson.Employee_Code;
								else
									paycomId = "0000";
								var firstname = matchedemp.firstName;
								var lastname = matchedemp.lastName;
								lastname = SanitizeFilename(lastname);

								string baseFileName = $"{paycomId}_{empId}_GC_{lastname}_{firstname}_{lastFour}_{coCode}_{year}_1095-C";
								string extention = ".pdf";
								string newFileName = baseFileName + extention;

								string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
								int counter = 1;
								if (System.IO.File.Exists(fullPath))
								{
									newFileName = $"{baseFileName}_{counter}{extention}";
									fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
									counter++;
								}
								System.IO.File.Copy(file, fullPath);
								Console.WriteLine("File renamed: " + newFileName);
							}
							else
							{
								Console.WriteLine("error");
							}
						}
						if (nameParts.Length == 3)
						{
							var lastName = nameParts[1] + " " + nameParts[2];
							var firstName = nameParts[0];

							EmployeeRecordADP matchedemp = null;
							bool found = false;

							foreach (var emp in Emp)
							{
								// Check if emp.uniqueID is not null
								if (emp.uniqueID != null && emp.uniqueIdTypeCode == "SSN")
								{
									// Check if emp.positions[0].coCode is not null
									if (emp.positions[0].coCode != null)
									{
										var empSsn = emp.uniqueID;
										string[] empSsnParts = empSsn.Split('-');
										var empLastFour = empSsnParts[2];
										if (coCode == emp.positions[0].coCode && lastFour == empLastFour && string.Equals(lastName.Substring(0, 3), emp.lastName.Substring(0, 3), StringComparison.OrdinalIgnoreCase)
											&& string.Equals(firstName.Substring(0, 3), emp.firstName.Substring(0, 3), StringComparison.OrdinalIgnoreCase))
										{
											matchedemp = emp;
											found = true;
											break; // Stop the loop if a match is found
										}
									}
								}
							}
							if (found == true && matchedemp != null)
							{
								var empId = "";
								if (matchedemp.positions[0].fileNumber != null)
									empId = matchedemp.positions[0].fileNumber;
								else empId = "000000";
								CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedemp.positions[0].fileNumber);
								var paycomId = "";
								if (paycomPerson != null)
									paycomId = paycomPerson.Employee_Code;
								else
									paycomId = "0000";
								var firstname = matchedemp.firstName;
								var lastname = matchedemp.lastName;
								lastname = SanitizeFilename(lastname);

								string baseFileName = $"{paycomId}_{empId}_GC_{lastname}_{firstname}_{lastFour}_{coCode}_{year}_1095-C";
								string extention = ".pdf";
								string newFileName = baseFileName + extention;

								string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
								int counter = 1;
								if (System.IO.File.Exists(fullPath))
								{
									newFileName = $"{baseFileName}_{counter}{extention}";
									fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
									counter++;
								}
								System.IO.File.Copy(file, fullPath);
								Console.WriteLine("File renamed: " + newFileName);
							}
							else
							{
								Console.WriteLine("error");
							}
						}
						if (nameParts.Length == 4)
						{
							var lastName = nameParts[1] + " " + nameParts[2] + " " + nameParts[3];
							var firstName = nameParts[0];

							EmployeeRecordADP matchedemp = null;
							bool found = false;

							foreach (var emp in Emp)
							{
								// Check if emp.uniqueID is not null
								if (emp.uniqueID != null && emp.uniqueIdTypeCode == "SSN")
								{
									// Check if emp.positions[0].coCode is not null
									if (emp.positions[0].coCode != null)
									{
										var empSsn = emp.uniqueID;
										string[] empSsnParts = empSsn.Split('-');
										var empLastFour = empSsnParts[2];
										if (coCode == emp.positions[0].coCode && lastFour == empLastFour && string.Equals(lastName.Substring(0, 3), emp.lastName.Substring(0, 3), StringComparison.OrdinalIgnoreCase)
											&& string.Equals(firstName.Substring(0, 3), emp.firstName.Substring(0, 3), StringComparison.OrdinalIgnoreCase))
										{
											matchedemp = emp;
											found = true;
											break; // Stop the loop if a match is found
										}
									}
								}
							}
							if (found == true && matchedemp != null)
							{
								var empId = "";
								if (matchedemp.positions[0].fileNumber != null)
									empId = matchedemp.positions[0].fileNumber;
								else empId = "000000";
								CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedemp.positions[0].fileNumber);
								var paycomId = "";
								if (paycomPerson != null)
									paycomId = paycomPerson.Employee_Code;
								else
									paycomId = "0000";
								var firstname = matchedemp.firstName;
								var lastname = matchedemp.lastName;
								lastname = SanitizeFilename(lastname);

								string baseFileName = $"{paycomId}_{empId}_GC_{lastname}_{firstname}_{lastFour}_{coCode}_{year}_1095-C";
								string extention = ".pdf";
								string newFileName = baseFileName + extention;

								string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
								int counter = 1;
								if (System.IO.File.Exists(fullPath))
								{
									newFileName = $"{baseFileName}_{counter}{extention}";
									fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
									counter++;
								}
								System.IO.File.Copy(file, fullPath);
								Console.WriteLine("File renamed: " + newFileName);
							}
							else
							{
								Console.WriteLine("error");
							}
						}
					}
					if (parts.Length == 5)
					{
						var coCode = parts[0];
						var year = parts[2];
						if (year == "23")
						{
							year = "2023";
						}
						else if (year == "22")
						{
							year = "2022";
						}
						var ssn = parts[3];
						string[] ssnParts = ssn.Split('-');
						var lastFour = ssnParts[2];
						lastFour = lastFour.Trim();
						var ext = parts[4];
						if (ext == "(1)")
						{
							ext = "_1";
						}

						var name = parts[1];
						name = RemoveSingleLetters(name);
						string[] nameParts = name.Split(" ");

						if (nameParts.Length == 2)
						{
							var lastName = nameParts[1];
							var firstName = nameParts[0];

							EmployeeRecordADP matchedemp = null;
							bool found = false;

							foreach (var emp in Emp)
							{
								// Check if emp.uniqueID is not null
								if (emp.uniqueID != null && emp.uniqueIdTypeCode == "SSN")
								{
									// Check if emp.positions[0].coCode is not null
									if (emp.positions[0].coCode != null)
									{
										var empSsn = emp.uniqueID;
										string[] empSsnParts = empSsn.Split('-');
										var empLastFour = empSsnParts[2];
										if (coCode == emp.positions[0].coCode && lastFour == empLastFour && string.Equals(lastName.Substring(0, 3), emp.lastName.Substring(0, 3), StringComparison.OrdinalIgnoreCase) 
											&& string.Equals(firstName.Substring(0, 3), emp.firstName.Substring(0, 3), StringComparison.OrdinalIgnoreCase))
										{
											matchedemp = emp;
											found = true;
											break; // Stop the loop if a match is found
										}
									}
								}
							}
							if (found == true && matchedemp != null)
							{
								var empId = "";
								if (matchedemp.positions[0].fileNumber != null)
									empId = matchedemp.positions[0].fileNumber;
								else empId = "000000";
								CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedemp.positions[0].fileNumber);
								var paycomId = "";
								if (paycomPerson != null)
									paycomId = paycomPerson.Employee_Code;
								else
									paycomId = "0000";
								var firstname = matchedemp.firstName;
								var lastname = matchedemp.lastName;
								lastname = SanitizeFilename(lastname);

								string baseFileName = $"{paycomId}_{empId}_GC_{lastname}_{firstname}_{lastFour}_{coCode}_{year}_1095-C_{ext}";
								string extention = ".pdf";
								string newFileName = baseFileName + extention;

								string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
								int counter = 1;
								if (System.IO.File.Exists(fullPath))
								{
									newFileName = $"{baseFileName}_{counter}{extention}";
									fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
									counter++;
								}
								System.IO.File.Copy(file, fullPath);
								Console.WriteLine("File renamed: " + newFileName);
							}
							else
							{
								Console.WriteLine("error");
							}
						}
						if (nameParts.Length == 3)
						{
							var lastName = nameParts[1] + " " + nameParts[2];
							var firstName = nameParts[0];

							EmployeeRecordADP matchedemp = null;
							bool found = false;

							foreach (var emp in Emp)
							{
								// Check if emp.uniqueID is not null
								if (emp.uniqueID != null && emp.uniqueIdTypeCode == "SSN")
								{
									// Check if emp.positions[0].coCode is not null
									if (emp.positions[0].coCode != null)
									{
										var empSsn = emp.uniqueID;
										string[] empSsnParts = empSsn.Split('-');
										var empLastFour = empSsnParts[2];
										if (coCode == emp.positions[0].coCode && lastFour == empLastFour && string.Equals(lastName.Substring(0, 3), emp.lastName.Substring(0, 3), StringComparison.OrdinalIgnoreCase)
											&& string.Equals(firstName.Substring(0, 3), emp.firstName.Substring(0, 3), StringComparison.OrdinalIgnoreCase))
										{
											matchedemp = emp;
											found = true;
											break; // Stop the loop if a match is found
										}
									}
								}
							}
							if (found == true && matchedemp != null)
							{
								var empId = "";
								if (matchedemp.positions[0].fileNumber != null)
									empId = matchedemp.positions[0].fileNumber;
								else empId = "000000";
								CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedemp.positions[0].fileNumber);
								var paycomId = "";
								if (paycomPerson != null)
									paycomId = paycomPerson.Employee_Code;
								else
									paycomId = "0000";
								var firstname = matchedemp.firstName;
								var lastname = matchedemp.lastName;
								lastname = SanitizeFilename(lastname);

								string baseFileName = $"{paycomId}_{empId}_GC_{lastname}_{firstname}_{lastFour}_{coCode}_{year}_1095-C_{ext}";
								string extention = ".pdf";
								string newFileName = baseFileName + extention;

								string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
								int counter = 1;
								if (System.IO.File.Exists(fullPath))
								{
									newFileName = $"{baseFileName}_{counter}{extention}";
									fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
									counter++;
								}
								System.IO.File.Copy(file, fullPath);
								Console.WriteLine("File renamed: " + newFileName);
							}
							else
							{
								Console.WriteLine("error");
							}
						}
						if (nameParts.Length == 4)
						{
							var lastName = nameParts[1] + " " + nameParts[2] + " " + nameParts[3];
							var firstName = nameParts[0];
							EmployeeRecordADP matchedemp = null;
							bool found = false;

							foreach (var emp in Emp)
							{
								// Check if emp.uniqueID is not null
								if (emp.uniqueID != null && emp.uniqueIdTypeCode == "SSN")
								{
									// Check if emp.positions[0].coCode is not null
									if (emp.positions[0].coCode != null)
									{
										var empSsn = emp.uniqueID;
										string[] empSsnParts = empSsn.Split('-');
										var empLastFour = empSsnParts[2];
										if (coCode == emp.positions[0].coCode && lastFour == empLastFour && string.Equals(lastName.Substring(0, 3), emp.lastName.Substring(0, 3), StringComparison.OrdinalIgnoreCase)
											&& string.Equals(firstName.Substring(0, 3), emp.firstName.Substring(0, 3), StringComparison.OrdinalIgnoreCase))
										{
											matchedemp = emp;
											found = true;
											break; // Stop the loop if a match is found
										}
									}
								}
							}
							if (found == true && matchedemp != null)
							{
								var empId = "";
								if (matchedemp.positions[0].fileNumber != null)
									empId = matchedemp.positions[0].fileNumber;
								else empId = "000000";
								CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedemp.positions[0].fileNumber);
								var paycomId = "";
								if (paycomPerson != null)
									paycomId = paycomPerson.Employee_Code;
								else
									paycomId = "0000";
								var firstname = matchedemp.firstName;
								var lastname = matchedemp.lastName;
								lastname = SanitizeFilename(lastname);

								string baseFileName = $"{paycomId}_{empId}_GC_{lastname}_{firstname}_{lastFour}_{coCode}_{year}_1095-C_{ext}";
								string extention = ".pdf";
								string newFileName = baseFileName + extention;

								string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
								int counter = 1;
								if (System.IO.File.Exists(fullPath))
								{
									newFileName = $"{baseFileName}_{counter}{extention}";
									fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
									counter++;
								}
								System.IO.File.Copy(file, fullPath);
								Console.WriteLine("File renamed: " + newFileName);
							}
							else
							{
								Console.WriteLine("error");
							}

						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace(" III", "")
				.Replace(" JR", "")
				.Replace(" jr.", "")
				.Replace(" jr", "")
				.Replace(" Jr.", "")
				.Replace(" Jr", "")
				.Replace(" JR.", "")
				.Replace(" SR.", "")
				.Replace(" SR", "")
				.Replace("'", "");
			}
			static string RemoveSingleLetters(string name)
			{
				// Check if the name is "A Lyan"
				if (name == "A LYAN")
				{
					return name;
				}
				// Split the name by spaces
				string[] nameParts = name.Split(' ');

				// Filter out parts that are single letters
				nameParts = nameParts.Where(part => part.Length > 1).ToArray();

				// Rejoin the remaining parts into a single string
				return string.Join(" ", nameParts);

			}
		}

		//To be used after splitting documents with Adobe Acrobat
		static async Task renameEmployeeProfiles()
		{
			try
			{
				string inputFolder = "C:\\Users\\rosej\\OneDrive\\Documents\\NinePeaks\\GenericCompany\\EmployeeProfiles\\ZWM";
				string outputFolder = "C:\\Users\\rosej\\OneDrive\\Documents\\NinePeaks\\GenericCompany\\EmployeeProfilesRenamed";

				string[] files = Directory.GetFiles(inputFolder);

				for (int i = 0; i < files.Length; i++)
				{
					var file = files[i];
					string nameNoExtention = System.IO.Path.GetFileNameWithoutExtension(file);
					string[] parts = nameNoExtention.Split("_");

					if (parts.Length == 4)
					{
						var posId = parts[3];
						posId = posId.Trim();

						EmployeeRecordADP matchedEmp = null;
						bool found = false;

						foreach (var emp in Emp)
						{
							if (posId == emp.positions[0].positionId)
							{
								matchedEmp = emp;
								found = true;
							}
						}
						if (matchedEmp != null && found == true)
						{
							var empId = "";
							if (matchedEmp.positions[0].fileNumber != null)
								empId = matchedEmp.positions[0].fileNumber;
							else empId = "000000";
							CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedEmp.positions[0].fileNumber);
							var paycomId = "";
							if (paycomPerson != null)
								paycomId = paycomPerson.Employee_Code;
							else
								paycomId = "0000";
							var firstName = matchedEmp.firstName;
							var lastName = matchedEmp.lastName;

							string baseFileName = $"{paycomId}_{empId}_GC_{lastName}_{firstName}_{posId}_EmployeeProfile";
							string extention = ".pdf";
							string newFileName = baseFileName + extention;

							string fullPath = System.IO.Path.Combine(outputFolder, newFileName);
							int counter = 1;
							if (System.IO.File.Exists(fullPath))
							{
								newFileName = $"{baseFileName}_{counter}{extention}";
								fullPath = System.IO.Path.Combine(outputFolder, newFileName);
								counter++;
							}
							System.IO.File.Copy(file, fullPath);
							Console.WriteLine("File renamed: " + newFileName);
						}
						else
						{

							Console.WriteLine("error");
						}

					}
					if (parts.Length == 3)
					{
						var posId = parts[2];
						posId = posId.Trim();

						EmployeeRecordADP matchedEmp = null;
						bool found = false;

						foreach (var emp in Emp)
						{
							if (posId == emp.positions[0].positionId)
							{
								matchedEmp = emp;
								found = true;
							}
						}
						if (matchedEmp != null && found == true)
						{
							var empId = "";
							if (matchedEmp.positions[0].fileNumber != null)
								empId = matchedEmp.positions[0].fileNumber;
							else empId = "000000";
							CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedEmp.positions[0].fileNumber);
							var paycomId = "";
							if (paycomPerson != null)
								paycomId = paycomPerson.Employee_Code;
							else
								paycomId = "0000";
							var firstName = matchedEmp.firstName;
							var lastName = matchedEmp.lastName;

							string baseFileName = $"{paycomId}_{empId}_GC_{lastName}_{firstName}_{posId}_EmployeeProfile";
							string extention = ".pdf";
							string newFileName = baseFileName + extention;

							string fullPath = System.IO.Path.Combine(outputFolder, newFileName);
							int counter = 1;
							if (System.IO.File.Exists(fullPath))
							{
								newFileName = $"{baseFileName}_{counter}{extention}";
								fullPath = System.IO.Path.Combine(outputFolder, newFileName);
								counter++;
							}
							System.IO.File.Copy(file, fullPath);
							Console.WriteLine("File renamed: " + newFileName);
						}
						else
						{
							Console.WriteLine("error");
						}
					}
					if (parts.Length == 2)
					{
						var posId = parts[1];
						posId = posId.Trim();
						posId = posId.Split("(")[0];
						posId = posId.Trim();

						EmployeeRecordADP matchedEmp = null;
						bool found = false;

						foreach (var emp in Emp)
						{
							if (posId == emp.positions[0].positionId)
							{
								matchedEmp = emp;
								found = true;
							}
						}
						if (matchedEmp != null && found == true)
						{
							var empId = "";
							if (matchedEmp.positions[0].fileNumber != null)
								empId = matchedEmp.positions[0].fileNumber;
							else empId = "000000";
							CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedEmp.positions[0].fileNumber);
							var paycomId = "";
							if (paycomPerson != null)
								paycomId = paycomPerson.Employee_Code;
							else
								paycomId = "0000";
							var firstName = matchedEmp.firstName;
							var lastName = matchedEmp.lastName;

							string baseFileName = $"{paycomId}_{empId}_GC_{lastName}_{firstName}_{posId}_EmployeeProfile";
							string extention = ".pdf";
							string newFileName = baseFileName + extention;

							string fullPath = System.IO.Path.Combine(outputFolder, newFileName);
							int counter = 1;
							if (System.IO.File.Exists(fullPath))
							{
								newFileName = $"{baseFileName}_{counter}{extention}";
								fullPath = System.IO.Path.Combine(outputFolder, newFileName);
								counter++;
							}
							System.IO.File.Copy(file, fullPath);
							Console.WriteLine("File renamed: " + newFileName);
						}
						else
						{
							Console.WriteLine("error");
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		static async Task HtmlToPdf()
		{
			try
			{

				string inputFolder = @"C:\Temp\Testing\GenericCompany\PayHistoryHTML\problem";
				string outputFolder = @"C:\Temp\Testing\GenericCompany\PayHistoryPdf\problem";

				HtmlToPdf converter = new HtmlToPdf();

				// Get all HTML file paths in the input folder
				string[] htmlFilePaths = Directory.GetFiles(inputFolder, "*.html");

				//foreach (string htmlFilePath in Directory.GetFiles(inputFolder, "*.html"))
				for (int f = 0; f < htmlFilePaths.Length; f++)
				{

					// Get the full path of the current HTML file
					string htmlFilePath = htmlFilePaths[f];

					string htmlFileName = System.IO.Path.GetFileNameWithoutExtension(htmlFilePath);

					string[] parts = htmlFileName.Split('_');

					string paycom = parts[0];
					string empid = parts[1];
					string lastName = parts[3];
					lastName = lastName.ToUpper();
					lastName = SanitizeFilename(lastName);
					string firstName = parts[4];
					firstName = firstName.ToUpper();
					firstName = SanitizeFilename(firstName);
					string posid = parts[5];
					string end = parts[6];

					htmlFileName = $"{paycom}_{empid}_GC_{lastName}_{firstName}_{posid}_{end}";

					string pdfFilePath = System.IO.Path.Combine(outputFolder, htmlFileName + ".pdf");

					// Check if a file with the same name already exists
					int counter = 1;
					string originalPdfFilePath = pdfFilePath;
					while (System.IO.File.Exists(pdfFilePath))
					{
						pdfFilePath = System.IO.Path.Combine(outputFolder, $"{htmlFileName}_{counter}.pdf");
						counter++;
					}

					try
					{
						SelectPdf.PdfDocument doc = converter.ConvertUrl(htmlFilePath);
						doc.Save(pdfFilePath);
						doc.Close();
						Console.WriteLine($"Converted {htmlFileName}.html to {System.IO.Path.GetFileName(pdfFilePath)}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Failed to convert {htmlFileName}.html: {ex.Message}");
					}
				}

				Console.WriteLine("Conversion process completed.");
			}



			catch (Exception ex)
			{
				// Handle exceptions gracefully
				Console.WriteLine($"An error occurred: {ex.Message}");
				// Additional error handling logic here			}
			}
			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace(" II", "")
				.Replace(" III", "")
				.Replace(" JR", "")
				.Replace(" JR.", "")
				.Replace(" Sr.", "")
				.Replace(" Sr", "")
				.Replace(".", "")
				.Replace("'", "")
				.Replace(",", "")
				.Replace(";", "")
				.Replace(":", "")
				.Replace("?", "")
				.Replace("\\", "")
				.Replace("*", "")
				.Replace(">", "")
				.Replace("<", "")
				.Replace("|", "");
			}

		}

		static async Task redoCorruptFiles()
		{
			try
			{
				// Define the paths to your folders
				string pdfFolder = @"C:\Temp\Testing\GenericCompany\PayHistoryPdf\corrupt";
				string htmlFolder = @"C:\Temp\Testing\GenericCompany\PayHistoryHTML";
				string outputFolder = @"C:\Temp\Testing\GenericCompany\PayHistoryPdf\replacecorrupt";

				HtmlToPdf converter = new HtmlToPdf();

				//// Get the list of filenames in each folder
				//string[] pdfFiles = Directory.GetFiles(pdfFolder, "*.pdf");
				//string[] htmlFiles = Directory.GetFiles(htmlFolder, "*.html");

				// Get the list of filenames in each folder
				string[] pdfFiles = Directory.GetFiles(pdfFolder, "*.pdf");
				string[] htmlFiles = Directory.GetFiles(htmlFolder, "*.html");

				// Function to get the base name up to the 6th underscore
				string GetBaseName(string filename)
				{
					var parts = System.IO.Path.GetFileNameWithoutExtension(filename).Split('_');
					return parts.Length > 6 ? string.Join("_", parts.Take(6)) : System.IO.Path.GetFileNameWithoutExtension(filename);

				}

				// Create sets of base names (filenames without extensions) from each folder
				var pdfBasenames = pdfFiles.Select(f => GetBaseName(f)).ToHashSet();
				var htmlBasenames = htmlFiles.Select(f => GetBaseName(f).ToUpper()).ToHashSet();

				// Find matches (convert pdfBasenames to uppercase for case-insensitive matching)
				var matches = pdfBasenames.Select(name => name.ToUpper()).Intersect(htmlBasenames);


				// Process matched files
				foreach (var match in matches)
				{
					string pdfFile = pdfFiles.First(f => GetBaseName(f).ToUpper() == match);
					string htmlFile = htmlFiles.First(f => GetBaseName(f).ToUpper() == match);

					Console.WriteLine($"Processing {pdfFile} and {htmlFile}");

					string htmlFileName = System.IO.Path.GetFileNameWithoutExtension(htmlFile);

					string[] parts = htmlFileName.Split('_');

					string paycom = parts[0];
					string empid = parts[1];
					string lastName = parts[3];
					lastName = lastName.ToUpper();
					lastName = SanitizeFilename(lastName);
					string firstName = parts[4];
					firstName = firstName.ToUpper();
					firstName = SanitizeFilename(firstName);
					string posid = parts[5];
					string end = parts[6];

					htmlFileName = $"{paycom}_{empid}_GC_{lastName}_{firstName}_{posid}_{end}";

					string pdfFilePath = System.IO.Path.Combine(outputFolder, htmlFileName + ".pdf");

					// Check if a file with the same name already exists
					int counter = 1;
					string originalPdfFilePath = pdfFilePath;
					while (System.IO.File.Exists(pdfFilePath))
					{
						pdfFilePath = System.IO.Path.Combine(outputFolder, $"{htmlFileName}_{counter}.pdf");
						counter++;
					}

					try
					{
						SelectPdf.PdfDocument doc = converter.ConvertUrl(htmlFile);
						doc.Save(pdfFilePath);
						doc.Close();
						Console.WriteLine($"Converted {htmlFileName}.html to {System.IO.Path.GetFileName(pdfFilePath)}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Failed to convert {htmlFileName}.html: {ex.Message}");
					}
				}

				Console.WriteLine("Conversion process completed.");
			}

			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace(" II", "")
				.Replace(" III", "")
				.Replace(" JR", "")
				.Replace(" JR.", "")
				.Replace(" Sr.", "")
				.Replace(" Sr", "")
				.Replace(".", "")
				.Replace("'", "")
				.Replace(",", "")
				.Replace(";", "")
				.Replace(":", "")
				.Replace("?", "")
				.Replace("\\", "")
				.Replace("*", "")
				.Replace(">", "")
				.Replace("<", "")
				.Replace("|", "");
			}
		}
		//Gets a lists of all employees and saves to json, either associate or position view
		static async Task employeeFetch()
		{
			var page = (await browser.PagesAsync()).First();
			var outputDirectory = "C:\\Temp\\Testing\\GenericCompany";
			//associate view
			//var employeeFetch = $"fetch('https://workforcenow.adp.com/mascsr/wfn/employeeidbar/metaservices/wfn/mobility/rest/hr/v2/employeeList?revealTaxId=true',\n" +
			//"{" +
			//"  'headers': {\n" +
			//"    'accept': 'application/json',\n" +
			//"    'accept-language': 'en-US,en;q=0.9',\n" +
			//"    'cache-control': 'no-cache',\n" +
			//"    'content-type': 'application/json',\n" +
			//"    'pragma': 'no-cache',\n" +
			//"    'sec-fetch-dest': 'empty',\n" +
			//"    'sec-fetch-mode': 'cors',\n" +
			//"    'sec-fetch-site': 'same-origin'\n" +
			//"  },\n" +
			//$"  'referrer': 'https://workforcenow.adp.com/theme/admin.html',\n" +
			//"   'referrerPolicy': 'strict-origin-when-cross-origin',\n" +
			//"    'body': \"{'preferences':{'positionView':false,'displayedPositionId':true,'companyView':'A','currentCompanyCode':'9200284510354','searchEffectiveDate':'T','isIncludeIndirectReportsAvailable':false,'includeIndirectReports':false}," +
			//					"'role':'practitioner','startIndex':1, 'endIndex':99999,'filterOid':'1:9001','loadOtherPositions':false,'sortingColumn':' last_name, first_name ','sortingDirection':' asc '}\", \n" +
			//"    'method': 'POST',\n" +
			//"    'mode': 'cors',\n" +
			//"    'credentials': 'include'\n" +
			//"})\n" +
			//".then(x => x.json())\n" +
			//".then(x => { return JSON.stringify(x, null, 5); });";

			//var employeeJson = await page.EvaluateExpressionAsync<string>(employeeFetch);
			//var exportPath = System.IO.Path.Combine(outputDirectory, "emps.json");
			//System.IO.File.WriteAllText(exportPath, employeeJson);

			//positionView
			var employeePosFetch = $"fetch('https://workforcenow.adp.com/mascsr/wfn/employeeidbar/metaservices/wfn/mobility/rest/hr/v2/employeeList?revealTaxId=true',\n" +
							"{" +
							"  'headers': {\n" +
							"    'accept': 'application/json',\n" +
							"    'accept-language': 'en-US,en;q=0.9',\n" +
							"    'cache-control': 'no-cache',\n" +
							"    'content-type': 'application/json',\n" +
							"    'pragma': 'no-cache',\n" +
							"    'sec-fetch-dest': 'empty',\n" +
							"    'sec-fetch-mode': 'cors',\n" +
							"    'sec-fetch-site': 'same-origin'\n" +
							"  },\n" +
							$"  'referrer': 'https://workforcenow.adp.com/theme/admin.html',\n" +
							"   'referrerPolicy': 'strict-origin-when-cross-origin',\n" +
							"    'body': \"{'preferences':{'positionView':true,'displayedPositionId':true,'companyView':'A','currentCompanyCode':'9200284510354','searchEffectiveDate':'T','isIncludeIndirectReportsAvailable':false,'includeIndirectReports':false}," +
												"'role':'practitioner','startIndex':1, 'endIndex':99999,'filterOid':'1:9001','loadOtherPositions':false,'sortingColumn':' last_name, first_name ','sortingDirection':' asc '}\", \n" +
							"    'method': 'POST',\n" +
							"    'mode': 'cors',\n" +
							"    'credentials': 'include'\n" +
							"})\n" +
							".then(x => x.json())\n" +
							".then(x => { return JSON.stringify(x, null, 5); });";

			var employeePosJson = await page.EvaluateExpressionAsync<string>(employeePosFetch);
			var exportPosPath = System.IO.Path.Combine(outputDirectory, "ADP GC empsX Pos View.json");
			System.IO.File.WriteAllText(exportPosPath, employeePosJson);
		}


		static async Task renameId()
		{
			try
			{
				var inputFolder = @"C:\Users\rosej\OneDrive\Documents\NinePeaks\GenericCompany\rename";
				var outputFolder = @"C:\Users\rosej\OneDrive\Documents\NinePeaks\GenericCompany\renamed";

				var files = Directory.GetFiles(inputFolder);

				foreach (var file in files)
				{
					string fileNameWithoutExtention = System.IO.Path.GetFileNameWithoutExtension(file);
					string[] parts = fileNameWithoutExtention.Split('_');

					var lastName = parts[3];
					var firstName = parts[4];

					CrosswalkRoot matchedemp = null;
					bool found = false;

					foreach (var emp in FullCrossWalkEmps)
					{
						if (string.Equals(lastName, emp.Legal_Lastname, StringComparison.OrdinalIgnoreCase) &&
								string.Equals(firstName, emp.Legal_Firstname, StringComparison.OrdinalIgnoreCase))
						{
							matchedemp = emp;
							found = true;
							break;
						}
					}

					if (found)
					{
						var paycomid = matchedemp.Employee_Code;

						var empid = "";
						if (matchedemp.ClockSeq != null)
							empid = matchedemp.ClockSeq;
						else
							empid = "000000";


						var baseFileName = $"{paycomid}_{empid}_GC_{lastName}_{firstName}_BenefitEnrollment";
						var extention = ".pdf";
						var newFileName = baseFileName + extention;
						var outPath = System.IO.Path.Combine(outputFolder, newFileName);
						int counter = 1;
						while (System.IO.File.Exists(outPath))
						{
							newFileName = $"{baseFileName}_{counter}{extention}";
							outPath = System.IO.Path.Combine(outputFolder, newFileName);
							counter++;
						}
						System.IO.File.Copy(file, outPath);
						Console.WriteLine("Renamed: " + newFileName);
					}
					else
					{
						Console.WriteLine("No paycom Id");

						var baseFileName = $"0000_000000_GC_{lastName}_{firstName}_BenefitEnrollment";
						var extention = ".pdf";
						var newFileName = baseFileName + extention;
						var outPath = System.IO.Path.Combine(outputFolder, newFileName);
						int counter = 1;
						while (System.IO.File.Exists(outPath))
						{
							newFileName = $"{baseFileName}_{counter}{extention}";
							outPath = System.IO.Path.Combine(outputFolder, newFileName);
							counter++;
						}
						System.IO.File.Copy(file, outPath);
						Console.WriteLine("Renamed: " + newFileName);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		static async Task compareJsonPdf()
		{
			try
			{
				string folderPath = "C:\\Users\\rosej\\OneDrive\\Documents\\NinePeaks\\GenericCompany\\Benefits\\rename";

				//var missingPeople = FindMissingPeople(folderPath);

				//find people that are in the json but not in the folderpath
				//if (missingPeople.Any())
				//{
				//	Console.WriteLine("Missing people:");
				//	foreach (var person in missingPeople)
				//	{
				//		Console.WriteLine($"{person.firstName} {person.lastName}");
				//	}
				//}
				//else
				//{
				//	Console.WriteLine("No missing people. All people are accounted for in the files.");
				//}

				var consecutiveDuplicates = FindConsecutiveDuplicatesInEmp();
				var duplicateNamesInFiles = FindDuplicateNamesInFiles(folderPath);
				var uniqueNames = FindUniqueNames(consecutiveDuplicates, duplicateNamesInFiles);

				//if (consecutiveDuplicates.Any())
				//{
				//	Console.WriteLine("\nConsecutive duplicate entries found in JSON:");
				//	foreach (var person in consecutiveDuplicates)
				//	{
				//		Console.WriteLine($"{person.firstName} {person.lastName}");
				//	}
				//}
				//else
				//{
				//	Console.WriteLine("\nNo consecutive duplicate entries found in the JSON file.");
				//}

				if (duplicateNamesInFiles.Any())
				{
					Console.WriteLine("\nDuplicate names found in files:");
					foreach (var name in duplicateNamesInFiles)
					{
						Console.WriteLine($"{name.FirstName} {name.LastName}");
					}
				}
				else
				{
					Console.WriteLine("\nNo duplicate names found in the files.");
				}

				//if (uniqueNames.Any())
				//{
				//	Console.WriteLine("\nUnique names between JSON and files:");
				//	foreach (var name in uniqueNames)
				//	{
				//		Console.WriteLine($"{name.FirstName} {name.LastName}");
				//	}
				//}
				//else
				//{
				//	Console.WriteLine("\nNo unique names found between JSON and files.");
				//}


				static (string FirstName, string LastName)? ExtractNamesFromFilename(string filename)
				{
					var parts = filename.Split('_');
					if (parts.Length >= 5)
					{
						string firstName = parts[4];
						string lastName = parts[3];
						return (firstName, lastName);
					}
					return null;
				}

				static List<string> GetFilesInFolder(string folderPath)
				{
					return Directory.GetFiles(folderPath).ToList();
				}

				static List<EmployeeRecordADP> FindMissingPeople(string folderPath)
				{
					// Get the list of files in the folder
					var files = GetFilesInFolder(folderPath);

					// Extract names from filenames
					var extractedNames = new HashSet<(string FirstName, string LastName)>();
					foreach (var file in files)
					{
						var name = ExtractNamesFromFilename(System.IO.Path.GetFileName(file));
						if (name != null)
						{
							extractedNames.Add(name.Value);
						}
					}

					// Find missing people
					return Emp.Where(person => !extractedNames.Contains((person.firstName, person.lastName))).ToList();
				}

				static List<EmployeeRecordADP> FindConsecutiveDuplicatesInEmp()
				{
					var duplicates = new List<EmployeeRecordADP>();

					for (int i = 1; i < Emp.Count; i++)
					{
						if (Emp[i].firstName == Emp[i - 1].firstName && Emp[i].lastName == Emp[i - 1].lastName)
						{
							duplicates.Add(Emp[i]);
						}
					}

					return duplicates;
				}

				static List<(string FirstName, string LastName)> FindDuplicateNamesInFiles(string folderPath)
				{
					var files = GetFilesInFolder(folderPath);
					var nameCounts = new Dictionary<(string FirstName, string LastName), int>();

					foreach (var file in files)
					{
						var name = ExtractNamesFromFilename(System.IO.Path.GetFileName(file));
						if (name != null)
						{
							if (nameCounts.ContainsKey(name.Value))
							{
								nameCounts[name.Value]++;
							}
							else
							{
								nameCounts[name.Value] = 1;
							}
						}
					}

					return nameCounts.Where(n => n.Value > 1).Select(n => n.Key).ToList();
				}

				static List<(string FirstName, string LastName)> FindUniqueNames(
					List<EmployeeRecordADP> consecutiveDuplicates,
					List<(string FirstName, string LastName)> duplicateNamesInFiles)
				{
					var jsonNames = consecutiveDuplicates.Select(p => (p.firstName, p.lastName)).ToHashSet();
					var fileNames = duplicateNamesInFiles.ToHashSet();

					var uniqueInJson = jsonNames.Except(fileNames);
					var uniqueInFiles = fileNames.Except(jsonNames);

					return uniqueInJson.Concat(uniqueInFiles).ToList();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		//used to rename docs after splitting with Adobe Acrobat
		static async Task renameW2C()
		{
			var page = (await browser.PagesAsync()).First();
			try
			{
				var inputDir = @"C:\\Users\\rosej\\OneDrive\\Documents\\NinePeaks\\GenericCompany\\W2c_Split";
				var outputDir = @"C:\\Users\\rosej\\OneDrive\\Documents\\NinePeaks\\GenericCompany\\W-2c";

				var w2cFiles = Directory.GetFiles(inputDir);

				foreach (var w2cFile in w2cFiles)
				{
					string fileNameWithoutExtention = System.IO.Path.GetFileNameWithoutExtension(w2cFile);
					string[] parts = fileNameWithoutExtention.Split('_');

					var lastName = parts[0];
					string firstName = parts[1];
					firstName = firstName.Split(" ")[0];
					var year = parts[2];
					var ssn = parts[3];
					string[] ssnParts = ssn.Split('-');
					var lastFour = ssnParts[2];
					var fileType = parts[4];


					EmployeeRecordADP matchedEmp = null;
					bool found = false;

					foreach (var emp in Emp)
					{

						if (emp.positions != null && emp.positions[0].status.Length > 0)
						{
							if (string.Equals(lastName, emp.lastName, StringComparison.OrdinalIgnoreCase) &&
								string.Equals(firstName, emp.firstName, StringComparison.OrdinalIgnoreCase))
							{
								matchedEmp = emp;
								found = true;
								//break;															
							}
						}
					}
					Console.WriteLine("Match found");
					if (found && matchedEmp != null)
					{
						//check if ssn matches
						var empLastFour = matchedEmp.uniqueID.Split("-")[2];
						if (empLastFour == lastFour)
						{
							CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedEmp.positions[0].fileNumber);
							var paycomId = "";
							if (paycomPerson != null)
								paycomId = paycomPerson.Employee_Code;
							else
								paycomId = "0000";
							var empid = "";
							if (matchedEmp.positions[0].fileNumber != null)
								empid = matchedEmp.positions[0].fileNumber;
							else
								empid = "000000";

							var newFileName = $"{paycomId}_{empid}_GC_{matchedEmp.lastName}_{matchedEmp.firstName}_{year}_{fileType}.pdf";
							var newFilePath = System.IO.Path.Combine(outputDir, newFileName);
							System.IO.File.Copy(w2cFile, newFilePath);
							Console.WriteLine("Renamed and moved " + newFileName);

						}
						else
						{
							Console.WriteLine("Wrong match");
						}

					}
					else
					{

						Console.WriteLine("An error has occurred");
					}

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}
		//used to rename docs after splitting with Adobe Acrobat
		static async Task renameW2()
		{

			var page = (await browser.PagesAsync()).First();
			try
			{
				var inputDir = @"C:\\Users\\rosej\\OneDrive\\Documents\\NinePeaks\\GenericCompany\\W2_Split";
				var outputDir = @"C:\\Users\\rosej\\OneDrive\\Documents\\NinePeaks\\GenericCompany\\W-2";

				var w2Files = Directory.GetFiles(inputDir);

				//foreach (var w2File in w2Files)
				for (int i = 7123; i < w2Files.Length; i++)
				{
					var w2File = w2Files[i];

					string fileNameWithoutExtention = System.IO.Path.GetFileNameWithoutExtension(w2File);
					Console.WriteLine("Employee: " + fileNameWithoutExtention);
					string[] parts = fileNameWithoutExtention.Split('_');
					if (parts.Length == 3)
					{
						var basefileName = fileNameWithoutExtention;
						var extension = ".pdf";
						var fileName = fileNameWithoutExtention + extension;

						var fullpath = System.IO.Path.Combine(outputDir, fileName);
						int counter = 1;
						if (System.IO.File.Exists(fullpath))
						{
							fileName = $"{basefileName}_{counter}{extension}";
							fullpath = System.IO.Path.Combine(outputDir, fileName);
							counter++;
						}
						System.IO.File.Copy(w2File, fullpath);
						Console.WriteLine("Copied file");
					}
					else if (parts.Length == 4)
					{
						var name = parts[0];
						var year = parts[1];
						var empid = parts[2];
						var coId = parts[3];
						var filetype = parts[4];

						//string[] nameparts = name.Split(' ');

						//if (nameparts.Length == 2)
						//{
						//var firstName = nameparts[0];
						//var lastName = nameparts[1];

						bool found = false;
						EmployeeRecordADP matchedEmployee = null;

						foreach (var emp in Emp)
						{
							if (emp.positions != null && emp.positions[0].status.Length > 0)
							{
								if (empid == emp.positions[0].fileNumber && coId == emp.positions[0].coCode)
								{
									found = true;
									matchedEmployee = emp;
									break;
								}
							}
						}

						//if (!found)
						//{
						//	continue;
						//}

						if (found && matchedEmployee != null)
						{
							CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedEmployee.positions[0].fileNumber);
							var paycomId = "";
							if (paycomPerson != null)
								paycomId = paycomPerson.Employee_Code;
							else
								paycomId = "0000";

							var empId = "";
							if (empId != null)
								empId = matchedEmployee.positions[0].fileNumber;
							else empId = "000000";

							var baseFileName = $"{paycomId}_{empId}_GC_{matchedEmployee.lastName}_{matchedEmployee.firstName}_{year}_{filetype}";
							var extension = ".pdf";
							var newFileName = baseFileName + extension;
							var fullPath = System.IO.Path.Combine(outputDir, newFileName);
							var altName = $"{baseFileName}_1{extension}";
							var altPath = System.IO.Path.Combine(outputDir, altName);

							if (baseFileName.EndsWith("(1)"))
							{
								newFileName = $"{baseFileName}_1{extension}";
								fullPath = System.IO.Path.Combine(outputDir, newFileName);
							}

							if (baseFileName.EndsWith("(2)"))
							{
								newFileName = $"{baseFileName}_2{extension}";
								fullPath = System.IO.Path.Combine(outputDir, newFileName);
							}


							if (baseFileName.EndsWith("(3)"))
							{
								newFileName = $"{baseFileName}_3{extension}";
								fullPath = System.IO.Path.Combine(outputDir, newFileName);
							}

							int counter = 1;
							if (System.IO.File.Exists(fullPath))

							{
								newFileName = $"{baseFileName}_{counter}{extension}";
								//newFileName = $"{baseFileName}_2{extension}";
								fullPath = System.IO.Path.Combine(outputDir, newFileName);
								counter++;
							}


							System.IO.File.Copy(w2File, fullPath);
							Console.WriteLine("Renamed and moved " + newFileName);
						}
						else
						{
							Console.WriteLine("Manual lookup");
						}

					}

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}

		//fetch to get list of all I9 emps in a tab and save to JSON (body: selectedTab to change tab)
		static async Task getI9emps()
		{
			var page = (await browser.PagesAsync()).First();
			var outputDirectory = @"C:\Temp\Testing\GenericCompany";
			try
			{
				await page.GoToAsync("https://workforcenow.adp.com/theme/index.html#/Process/EI9Management");
				await page.WaitForTimeoutAsync(3000);

				var I9Fetch = @"
fetch('https://workforcenow.adp.com/mascsr/wfn/compliance/metaservices/ei9/ei9Main/getDashboardEmployeeByIndex?includePrehire=false',
{
  headers: {
    'accept': '*/*',
    'accept-language': 'en-US',
    'content-type': 'application/json',
    'locale': 'en_US',
    'sec-ch-ua': '""Not/A)Brand"";v=""24"", ""Chromium"";v=""128"", ""Google Chrome"";v=""128""',
    'sec-ch-ua-mobile': '?0',
    'sec-ch-ua-platform': '""Windows""',
    'sec-fetch-dest': 'empty',
    'sec-fetch-mode': 'cors',
    'sec-fetch-site': 'same-origin',
	'transid': '92bbfecd-04c2-4255-ab85-463e6f161d41',
	'x-dtpc': '34$378789667_489h73vRQHFUFOFCSEUHPABCUVQHSHMFPLWKMSU-0e0'
  },
  referrer: 'https://workforcenow.adp.com/theme/admin.html',
  referrerPolicy: 'strict-origin-when-cross-origin',
  body: JSON.stringify({
	selectedTab: 'CLOSE',
	filterStatusOid: 'ALL',
	searchTerm: 'none',	
    startIndex: 0,
    stopIndex: 5137,
	sortCategory: '',
	sortDirection: 'ASC'
  }),
  method: 'POST',
  mode: 'cors',
  credentials: 'include'
})
.then(x => x.json())
.then(x => JSON.stringify(x, null, 5));
";

				var I9Json = await page.EvaluateExpressionAsync<string>(I9Fetch);
				var I9Path = System.IO.Path.Combine(outputDirectory, "I9emps2.json");
				System.IO.File.WriteAllText(I9Path, I9Json);
				Console.WriteLine("File Written");


			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}
		//rename manual screenshots
		static async Task renameI9()
		{
			var page = (await browser.PagesAsync()).First();
			try
			{
				var inputDir = @"C:\Temp\Testing\GenericCompany\I9ScreenshotManual";
				var outputDir = @"C:\Temp\Testing\GenericCompany\I9ScreenshotManual\renamed";

				string[] files = Directory.GetFiles(inputDir);
				Array.Sort(files, new NaturalStringComparer());

				int g = 5126;

				for(int i=0; i<files.Length; i++)
				{
					var file = files[i];
					// Sort files in alphabetical order
					
					Console.WriteLine("File index no.: " + i);

					var json = System.IO.File.ReadAllText("C:\\Temp\\Testing\\GenericCompany\\I9emps.json");
					var I9Emps = JsonConvert.DeserializeObject<I9EmpRoot>(json);

					//for(int g= 4906; g < I9Emps.records.Count; g++)
					if(g<I9Emps.records.Count)
					{
						var I9Emp = I9Emps.records[g];
						Console.WriteLine("Emp index no.: " + g);
						var systemName = I9Emp.section1FullName;
						string[] nameParts = systemName.Split(',');
						var sysLast = nameParts[0].Trim();
						sysLast = SanitizeFilename(sysLast);
						var sysFirst = nameParts[1].Trim();
						sysFirst = SanitizeFilename(sysFirst);
						
						var lastName = "";
						if (I9Emp.systemLastName != null)
							lastName = SanitizeFilename(I9Emp.systemLastName);
						else
							lastName = sysLast;

						var firstName = "";
						if (I9Emp.systemFirstName != null)
							firstName = SanitizeFilename(I9Emp.systemFirstName);
						else
							firstName = sysFirst;

						var clockSeq = I9Emp.fileNo?.PadLeft(6, '0') ?? "000000";


						CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == clockSeq);
						var paycomId = "";
						if (paycomPerson != null)
							paycomId = paycomPerson.Employee_Code;
						else
							paycomId = "0000";

						Console.WriteLine(firstName + " " + lastName);

						var baseFileName1 = $"{paycomId}_{clockSeq}_GC_{lastName}_{firstName}_Closed_Section1_I9";
						var baseFileName2 = $"{paycomId}_{clockSeq}_GC_{lastName}_{firstName}_Closed_E-Verify_I9";
						var extention = ".png";
						var newFileName1 = baseFileName1+extention;
						var newFileName2 = baseFileName2+extention;

						if (i % 2 == 0) // Even index
						{
							var outpath1 = System.IO.Path.Combine(outputDir, newFileName1);
							System.IO.File.Copy(file, outpath1);
							Console.WriteLine("wrote file: " + newFileName1);
							await page.WaitForTimeoutAsync(1000);
						}
						else // Odd index
						{
							var outpath2 = System.IO.Path.Combine(outputDir, newFileName2);
							System.IO.File.Copy(file, outpath2);
							Console.WriteLine("wrote file: " + newFileName2);
							await page.WaitForTimeoutAsync(1000);

						}
						// Increment g after processing two files
						if (i % 2 != 0)
						{
							g++;
						}
					}
				}
			}

			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace(" II", "")
				.Replace(" III", "")
				.Replace(" IV", "")
				.Replace(" Jr.", "")
				.Replace(" Jr", "")
				.Replace(" Sr.", "")
				.Replace(" Sr", "")
				.Replace(".", "")
				.Replace("'", "")
				.Replace(",", "")
				.Replace(";", "")
				.Replace(":", "")
				.Replace("?", "")
				.Replace("\\", "")
				.Replace("*", "")
				.Replace(">", "")
				.Replace("<", "")
				.Replace("|", "");
			}

		}
		//to get screenshots 
		static async Task getI9info()
		{
			var page = (await browser.PagesAsync()).First();
			//await page.GoToAsync("https://workforcenow.adp.com/theme/index.html#/Process/EI9Management");
			//Console.WriteLine("Page loaded");
			//await page.WaitForTimeoutAsync(4000);

			try
			{
				//	//active employees
				//	for (int i = 14; i < 15; i++)
				//	{
				//		I9Root datalist = new I9Root();
				//		string targeturl = "https://workforcenow.adp.com/mascsr/wfn/compliance/metaservices/ei9/ei9Data/retrieveFormData";

				//		//Create request listener to log request for troubleshooting
				//		EventHandler<RequestEventArgs> requestHandler = (sender, e) =>
				//		{
				//			if (e.Request.Url.Contains(targeturl))
				//			{
				//				Console.WriteLine($"Request: {e.Request.Url}");
				//			}
				//		};

				//		//Create response listener to capture response body from checkstubslight request
				//		EventHandler<ResponseCreatedEventArgs> responseHandler = async (sender, e) =>
				//		{
				//			if (e.Response.Url.Contains(targeturl))
				//			{
				//				Console.WriteLine($"Response: {e.Response.Url} Status: {e.Response.Status}");
				//				string responseBody = await e.Response.TextAsync();
				//				//datalist = JsonConvert.DeserializeObject<List<Root>>(responseBody);
				//				datalist = JsonConvert.DeserializeObject<I9Root>(responseBody);
				//			}

				//		};
				//		// Subscribe to the events listener
				//		page.Request += requestHandler;
				//		page.Response += responseHandler;

				//		var nameLink = await page.QuerySelectorAsync($"#EI9_DASHBOARD_GRID_{i} > div > div > div > div.vdl-col-xs.ei9-grid-cell.mdf-d-table > a");
				//		await page.WaitForTimeoutAsync(5000);
				//		if (nameLink != null)
				//		{
				//			await nameLink.ClickAsync();
				//		}
				//		await page.WaitForTimeoutAsync(8000);

				//		bool found = false;
				//		EmployeeRecordADP matchedEmployee = null;
				//		try
				//		{
				//			// Check if ssn is null and throw an exception if it is
				//			if (datalist?.section1Info?.section1?.ssn == null)
				//			{
				//				throw new NullReferenceException("SSN is null");
				//			}
				//			string ssn = datalist.section1Info.section1.ssn;
				//			string formattedSSN = $"{ssn.Substring(0, 3)}-{ssn.Substring(3, 2)}-{ssn.Substring(5, 4)}";
				//			foreach (var emp in Emp)
				//			{
				//				if (emp.positions != null && emp.positions[0].status.Length > 0)
				//				{
				//					if (formattedSSN == emp.uniqueID)
				//					{
				//						found = true;
				//						matchedEmployee = emp;
				//						break;
				//					}
				//				}
				//			}
				//		}
				//		catch (NullReferenceException)
				//		{
				//			foreach (var emp in Emp)
				//			{
				//				if (emp.positions != null && emp.positions[0].status.Length > 0)
				//				{
				//					if (datalist.section1Info.employeeOid == emp.employeeOID)
				//					{
				//						found = true;
				//						matchedEmployee = emp;
				//						break;
				//					}
				//				}
				//			}
				//		}

				//		if (found && matchedEmployee != null)
				//		{
				//			CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedEmployee.positions[0].fileNumber);
				//			var paycomId = "";
				//			if (paycomPerson != null)
				//				paycomId = paycomPerson.Employee_Code;
				//			else
				//				paycomId = "0000";

				//			var empId = matchedEmployee.positions[0].fileNumber;
				//			var lastName = matchedEmployee.lastName;
				//			lastName = SanitizeFilename(lastName);
				//			var firstName = matchedEmployee.firstName;
				//			firstName = SanitizeFilename(firstName);

				//			string newFilename = $"{paycomId}_{empId}_GC_{lastName}_{firstName}";

				//			var vPOptions = new ViewPortOptions()
				//			{
				//				DeviceScaleFactor = 1,
				//				Height = 1440,
				//				Width = 900
				//			};
				//			await page.SetViewportAsync(vPOptions);
				//			await page.WaitForTimeoutAsync(2500);

				//			//await page.SetViewportAsync(new ViewPortOptions
				//			//{
				//			//	Width = 900,
				//			//	Height = 1440
				//			//});
				//			//await page.WaitForTimeoutAsync(1000);

				//			var clip = new Clip
				//			{
				//				X = 0, // Custom X position
				//				Y = 200, // Custom Y position
				//				Width = 920, // Custom width
				//				Height = 700 // Custom height
				//			};

				//			var outDir = @"C:\Temp\Testing\GenericCompany\I9Screenshots";
				//			string section1name = $"{newFilename}_Active_Section1_I-9x.png";

				//			var outPath = System.IO.Path.Combine(outDir, section1name);

				//			var screenshot = await page.ScreenshotDataAsync(new ScreenshotOptions
				//			{
				//				Clip = clip,
				//				//FullPage = true // Ensures the full content is captured
				//			});

				//			await page.WaitForTimeoutAsync(3000);

				//			System.IO.File.WriteAllBytes(outPath, screenshot);
				//			Console.WriteLine("Screenshot Taken: " + outPath);

				//			var eVerify = await page.QuerySelectorAsync("#EI9_SUMMARY_TABS__tab__2");
				//			await page.WaitForTimeoutAsync(1000);
				//			if (eVerify != null)
				//			{
				//				await eVerify.ClickAsync();
				//			}
				//			await page.WaitForTimeoutAsync(3000);

				//			string eVerifyname = $"{newFilename}_Active_E-Verify_I-9x.png";
				//			var outPath2 = System.IO.Path.Combine(outDir, eVerifyname);

				//			var screenshot2 = await page.ScreenshotDataAsync(new ScreenshotOptions
				//			{
				//				Clip = clip,
				//				//FullPage = true // Ensures the full content is captured
				//			});

				//			await page.WaitForTimeoutAsync(3000);

				//			System.IO.File.WriteAllBytes(outPath2, screenshot2);
				//			Console.WriteLine("Screenshot Taken: " + outPath2);

				//			await page.WaitForTimeoutAsync(1000);

				//			await page.Keyboard.PressAsync("Escape");

				//			await page.WaitForTimeoutAsync(3000);
				//		}
				//	}
				//	var closedTab = await page.QuerySelectorAsync("#EI9_DASHBOARD_TABS__tab__1");
				//	await page.WaitForTimeoutAsync(2000);
				//	if (closedTab != null)
				//	{
				//		await closedTab.ClickAsync();
				//	}
				//	await page.WaitForTimeoutAsync(3000);
				//closed employees
				for (int i = 12; i < 22; i++)
				{
					//refreshing page helps elements be found
					await page.GoToAsync("https://workforcenow.adp.com/theme/index.html#/Process/EI9Management");
					Console.WriteLine("Page loaded");
					await page.WaitForTimeoutAsync(4000);

					await page.SetViewportAsync(new ViewPortOptions
					{
						Width = 1440,
						Height = 3300
					});
					await page.WaitForTimeoutAsync(1000);

					I9Root datalist = new I9Root();
					string targeturl = "https://workforcenow.adp.com/mascsr/wfn/compliance/metaservices/ei9/ei9Data/retrieveFormData";

					//Create request listener to log request for troubleshooting
					EventHandler<RequestEventArgs> requestHandler = (sender, e) =>
					{
						if (e.Request.Url.Contains(targeturl))
						{
							Console.WriteLine($"Request: {e.Request.Url}");
						}
					};

					//Create response listener to capture response body from checkstubslight request
					EventHandler<ResponseCreatedEventArgs> responseHandler = async (sender, e) =>
					{
						if (e.Response.Url.Contains(targeturl))
						{
							Console.WriteLine($"Response: {e.Response.Url} Status: {e.Response.Status}");
							string responseBody = await e.Response.TextAsync();
							//datalist = JsonConvert.DeserializeObject<List<Root>>(responseBody);
							datalist = JsonConvert.DeserializeObject<I9Root>(responseBody);
						}

					};
					// Subscribe to the events listener
					page.Request += requestHandler;
					page.Response += responseHandler;

					var nameLink = await page.QuerySelectorAsync($"#EI9_DASHBOARD_GRID_{i} > div > div > div > div.vdl-col-xs.ei9-grid-cell.mdf-d-table > a");
					await page.WaitForTimeoutAsync(5000);
					if (nameLink != null)
					{
						await nameLink.ClickAsync();
					}
					else
					{
						while (nameLink == null)
						{
							// Press the "Page Down" key
							await page.Keyboard.PressAsync("PageDown");
							await page.WaitForTimeoutAsync(2000); // Wait for the page to load more content

							// Try to find the element again
							nameLink = await page.QuerySelectorAsync($"#EI9_DASHBOARD_GRID_{i} > div > div > div > div.vdl-col-xs.ei9-grid-cell.mdf-d-table > a");

							if (nameLink != null)
							{
								// Element found, break the loop and click it
								await nameLink.ClickAsync();
							}
						}
					}
					await page.WaitForTimeoutAsync(2000);

					string ssn = datalist.section1Info.section1.ssn;
					string formattedSSN = $"{ssn.Substring(0, 3)}-{ssn.Substring(3, 2)}-{ssn.Substring(5, 4)}";

					bool found = false;
					EmployeeRecordADP matchedEmployee = null;
					try
					{
						//string ssn = datalist.section1Info.section1.ssn;
						//string formattedSSN = $"{ssn.Substring(0, 3)}-{ssn.Substring(3, 2)}-{ssn.Substring(5, 4)}";
						// Check if ssn is null and throw an exception if it is
						if (datalist?.section1Info?.section1?.ssn == null)
						{
							throw new NullReferenceException("SSN is null");
						}

						foreach (var emp in Emp)
						{
							if (emp.positions != null && emp.positions[0].status.Length > 0)
							{
								//if (formattedSSN == emp.uniqueID)
								if(datalist.ei9Main.employeeOid == emp.employeeOID)
								{
									found = true;
									matchedEmployee = emp;
									break;
								}
							}
						}
					}
					catch (NullReferenceException)
					{
						foreach (var emp in Emp)
						{
							if (emp.positions != null && emp.positions[0].status.Length > 0)
							{
								if (datalist.section1Info.employeeOid == emp.employeeOID)
								{
									found = true;
									matchedEmployee = emp;
									break;
								}
							}
						}
					}

					if (found && matchedEmployee != null)
					{
						CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == matchedEmployee.positions[0].fileNumber);
						var paycomId = "";
						if (paycomPerson != null)
							paycomId = paycomPerson.Employee_Code;
						else
							paycomId = "0000";

						var empId = matchedEmployee.positions[0].fileNumber;
						var lastName = matchedEmployee.lastName;
						lastName = SanitizeFilename(lastName);
						var firstName = matchedEmployee.firstName;
						firstName = SanitizeFilename(firstName);

						string newFilename = $"{paycomId}_{empId}_GC_{lastName}_{firstName}";

						//var vPOptions2 = new ViewPortOptions()
						//{
						//	DeviceScaleFactor = 1,
						//	Height = 1440,
						//	Width = 900
						//};
						//await page.SetViewportAsync(vPOptions2);
						//await page.WaitForTimeoutAsync(2500);

						await page.SetViewportAsync(new ViewPortOptions
						{
							Width = 1440,
							Height = 900
						});
						await page.WaitForTimeoutAsync(1000);


						var clip2 = new Clip
						{
							X = 230, // Custom X position
							Y = 5, // Custom Y position
							Width = 1210, // Custom width
							Height = 720 // Custom height
						};

						//var clip = new Clip
						//{
						//	X = 0, // Custom X position
						//	Y = 200, // Custom Y position
						//	Width = 920, // Custom width
						//	Height = 700 // Custom height
						//};
						var outDir = @"C:\Temp\Testing\GenericCompany\I9Screenshots";
						string section1name = $"{newFilename}_Expiring_Section1_I-9.png";

						var outPath = System.IO.Path.Combine(outDir, section1name);

						var screenshotx = await page.ScreenshotDataAsync(new ScreenshotOptions
						{
							//Clip = clip2,
							FullPage = true // Ensures the full content is captured
						});

						await page.WaitForTimeoutAsync(3000);

						System.IO.File.WriteAllBytes(outPath, screenshotx);
						Console.WriteLine("Screenshot Taken: " + outPath);

						var screenshot3 = await page.ScreenshotDataAsync(new ScreenshotOptions
						{
							Clip = clip2,
							//FullPage = true // Ensures the full content is captured
						});

						await page.WaitForTimeoutAsync(3000);

						System.IO.File.WriteAllBytes(outPath, screenshot3);
						Console.WriteLine("Screenshot Taken: " + outPath);

						var eVerify = await page.QuerySelectorAsync("#EI9_SUMMARY_TABS__tab__2");
						await page.WaitForTimeoutAsync(1000);
						if (eVerify != null)
						{
							await eVerify.ClickAsync();
						}
						await page.WaitForTimeoutAsync(3000);

						string eVerifyname = $"{newFilename}_Expiring_E-Verify_I-9.png";
						var outPath2 = System.IO.Path.Combine(outDir, eVerifyname);

						var screenshot4 = await page.ScreenshotDataAsync(new ScreenshotOptions
						{
							Clip = clip2,
							//FullPage = true // Ensures the full content is captured
						});

						await page.WaitForTimeoutAsync(3000);

						System.IO.File.WriteAllBytes(outPath2, screenshot4);
						Console.WriteLine("Screenshot Taken: " + outPath2);

						await page.WaitForTimeoutAsync(1000);

						await page.Keyboard.PressAsync("Escape");

						await page.WaitForTimeoutAsync(3000);
					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace(" II", "")
				.Replace(" III", "")
				.Replace(" IV", "")
				.Replace(" Jr.", "")
				.Replace(" Jr", "")
				.Replace(" Sr.", "")
				.Replace(" Sr", "")
				.Replace(".", "")
				.Replace("'", "")
				.Replace(",", "")
				.Replace(";", "")
				.Replace(":", "")
				.Replace("?", "")
				.Replace("\\", "")
				.Replace("*", "")
				.Replace(">", "")
				.Replace("<", "")
				.Replace("|", "");
			}
		}
		static async Task renamePdf()
		{
			var directory = @"C:\Users\rosej\OneDrive\Documents\NinePeaks\GenericCompany\EmployeeProfilesRenamed";
			var outDir = @"C:\Users\rosej\OneDrive\Documents\NinePeaks\GenericCompany\EmployeeProfilesFinal";

			var files = Directory.GetFiles(directory);

			foreach (var file in files)

			{
				try
				{

					string nameNoExtention = System.IO.Path.GetFileNameWithoutExtension(file);

					string[] parts = nameNoExtention.Split("_");

					var paycom = parts[0];
					var empid = parts[1];
					var lastName = parts[3];
					lastName = SanitizeFilename(lastName);
					var fullName = parts[4];
					//firstName = firstName.Trim();
					//firstName = SanitizeFilename(firstName);
					string[] nameParts = fullName.Split(' '); // Split the string into parts

					string firstName;

					if (nameParts.Length == 1)
					{
						// If there's only one word, it's the first name
						firstName = nameParts[0].Trim();
					}
					else if (nameParts.Length > 1 && nameParts[1].Trim().Length == 1)
					{
						// If the second part exists and is a single letter, use only the first part as the first name
						firstName = nameParts[0].Trim();
					}
					else
					{
						// If the second part is not a single letter, use the original full name
						firstName = fullName.Trim();
					}
					var posId = parts[5];
					var end = parts[6];

					var baseFileName = $"{paycom}_{empid}_GC_{lastName}_{firstName}_{posId}_{end}";
					var extention = ".pdf";
					var newFileName = baseFileName + extention;
					Console.WriteLine("New filename: " + newFileName);

					var outPath = System.IO.Path.Combine(outDir, newFileName);
					int counter = 1;
					if (System.IO.File.Exists(outPath))
					{
						newFileName = $"{baseFileName}_{counter}{extention}";
						outPath = System.IO.Path.Combine(outDir, newFileName);
						counter++;
					}

					System.IO.File.Copy(file, outPath);
					Console.WriteLine("Wrote file: " + newFileName);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}

			}
			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace(" III", "")
				.Replace(" JR", "")
				.Replace(" Jr", "")
				.Replace(" Jr.", "");
			}


		}
		//download documents with Puppeteer
		static async Task getEnrollmentHistory()
		{
			var page = (await browser.PagesAsync()).First();
			var downloadPath = "C:\\Temp\\Testing\\GenericCompany\\Benefits\\ADP Workforce Now - Enrollment History.pdf";
			await page.GoToAsync("https://workforcenow.adp.com/theme/index.html#/People/PeopleTabBenefitsCategoryBenefitsProfile");

			var benefitsButton = await page.QuerySelectorAsync("#benefits-profile-enrollment-history-link");
			await page.WaitForTimeoutAsync(3000);
			if (benefitsButton != null)
			{
				await benefitsButton.ClickAsync();
			}
			try
			{
				//set filter for all employees
				for (int i = 0; i < Emp.Count; i++)
				{
					var emp = Emp[i];

					var printButton = await page.WaitForSelectorAsync("#bpe_history_print_btn");
					await page.WaitForTimeoutAsync(2000);
					await printButton.ClickAsync();

					await page.WaitForTimeoutAsync(3000);
					if (System.IO.File.Exists(downloadPath))
					{
						var lastname = emp.lastName;
						lastname = SanitizeFilename(lastname);
						var firstname = emp.firstName;
						firstname = SanitizeFilename(firstname);

						CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == emp.positions[0].fileNumber);
						var paycomId = "";
						if (paycomPerson != null)
							paycomId = paycomPerson.Employee_Code;
						else
							paycomId = "0000";

						var empId = "";
						if (emp.positions[0].fileNumber != null)
							empId = emp.positions[0].fileNumber;
						else
							empId = "000000";

						var newFileName = $"{paycomId}_{empId}_GC_{lastname}_{firstname}_BenefitEnrollment.pdf";
						System.IO.File.Move(downloadPath, newFileName);
						await page.WaitForTimeoutAsync(2000);
						Console.WriteLine("File written and moved: " + downloadPath);
					}
					//check to make sure file was moved. Sometimes file is moved but copy still exists in directory
					if (System.IO.File.Exists(downloadPath))
					{
						System.IO.File.Delete(downloadPath);
					}
					var rightButton = await page.QuerySelectorAsync("#empidbar-nav-icons-right-xl");
					await page.WaitForTimeoutAsync(2000);
					if (rightButton != null)
					{
						await rightButton.ClickAsync();
					}
					await page.WaitForTimeoutAsync(3000);
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace(" II", "")
				.Replace(" III", "")
				.Replace(" IV", "")
				.Replace(" Jr.", "")
				.Replace(" Jr", "")
				.Replace(" Sr.", "")
				.Replace(" Sr", "")
				.Replace(".", "")
				.Replace("'", "")
				.Replace(",", "")
				.Replace(";", "")
				.Replace(":", "")
				.Replace("?", "")
				.Replace("\\", "")
				.Replace("*", "")
				.Replace(">", "")
				.Replace("<", "")
				.Replace("|", "");
			}
		}
		//get documents by getting url link in HTML
		static async Task GetLMSPdf()
		{
			var page = (await browser.PagesAsync()).First();
			try
			{
				////PART 1
				await page.GoToAsync("https://tms.adp.com/lms/servlet/lms/FRFILE?SHARED=Y");
				await page.WaitForTimeoutAsync(2000);

				//TTAI
				await page.GoToAsync("https://tms.adp.com/lms/servlet/lms/FRFILE?RID=ADP000198072&SHARED=Y");
				//YKTA
				//await page.GoToAsync("https://tms.adp.com/lms/servlet/lms/FRFILE?RID=ADP000033214&PID=&SHARED=Y");
				await page.WaitForTimeoutAsync(2000);

				// Define the JavaScript code to evaluate
				var script = @"
				        Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
				            .map(a => a.outerHTML)
				    ";
				var elements = await page.EvaluateExpressionAsync<string[]>(script);

				// Define the output file path
				var filePath = "jsonData/TTAI.json";
				//var filePath = @"ykta/ykta_folder.json";

				// Serialize the elements to JSON
				var json = JsonConvert.SerializeObject(elements, Formatting.Indented);
				System.IO.File.WriteAllText(filePath, json);
				Console.WriteLine("Json file written");

				////PART 2, load the json
				//filter out lines we don't want
				//Read the content of the file
				string jsons = System.IO.File.ReadAllText(filePath);
				// Deserialize the JSON content to a list of strings
				var lines = JsonConvert.DeserializeObject<List<string>>(jsons);
				// Filter lines based on the specified pattern
				var filtereds = FilterLines(lines);
				// Serialize the filtered lines back to JSON
				string filteredjson = JsonConvert.SerializeObject(filtereds, Formatting.Indented);

				System.IO.File.WriteAllText(filePath, filteredjson);
				//file cleaned up
				Console.WriteLine($"Processed file: {filePath}");


				//Read the JSON file into a string
				var jsonString = System.IO.File.ReadAllText(filePath);
				// Deserialize the JSON string into a list of strings
				var links = JsonConvert.DeserializeObject<List<string>>(jsonString);

				for (int i = 0; i < links.Count; i++)
				{
					var link = links[i];


					var extractedText = ExtractTextBetween(link, '\"', '&');
					Console.WriteLine(extractedText);

					var filename = ExtractTextBetween(link, '>', '<');
					Console.WriteLine(filename);

					// Sanitize the filename
					filename = SanitizeFilename(filename);
					Console.WriteLine($"Trimmed and sanitized filename: {filename}");

					await page.GoToAsync($"https://tms.adp.com{extractedText}");
					await page.WaitForTimeoutAsync(5000);

					// Define the JavaScript code to evaluate
					var otherLinks = @"
				        Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
				            .map(a => a.outerHTML)
				    ";
					var childLinks = await page.EvaluateExpressionAsync<string[]>(otherLinks);
					// Define the output file path
					var childPath = $@"jsonData/{filename}.json";
					//var childPath = $@"F:\IT Company\Solutions\GenericCompany\bin\Debug\ykta\{filename}.json";

					// Serialize the elements to JSON
					var childjson = JsonConvert.SerializeObject(childLinks, Formatting.Indented);
					System.IO.File.WriteAllText(childPath, childjson);
					Console.WriteLine($"Json file {i} written");
				}

				//ykta step
				//filter json files for lines we will need

				var folderPath = @"jsonData";

				// Get all JSON files in the folder
				var jsonFiles = Directory.GetFiles(folderPath, "*.json");
				//PART 3, CLEAN UP FOLDER FILES
				foreach (var jsonFile in jsonFiles)
				{
					// Read the content of the file
					string jsonContent = System.IO.File.ReadAllText(jsonFile);
					// Deserialize the JSON content to a list of strings
					var linez = JsonConvert.DeserializeObject<List<string>>(jsonContent);
					// Filter lines based on the specified pattern
					var filteredLines = FilterLines(linez);
					// Serialize the filtered lines back to JSON
					string filteredJson = JsonConvert.SerializeObject(filteredLines, Formatting.Indented);

					System.IO.File.WriteAllText(jsonFile, filteredJson);
					Console.WriteLine($"Processed file: {jsonFile}");
				}

				await page.GoToAsync("https://tms.adp.com/lms/servlet/lms/FRFILE?RID=ADP000214106&SHARED=Y");
				//YKTA
				//await page.GoToAsync("https://tms.adp.com/lms/servlet/lms/FRFILE?RID=ADP000033214&PID=&SHARED=Y");
				await page.WaitForTimeoutAsync(2000);

				////PART 4 FIND OTHER FOLDERS
				string[] files = Directory.GetFiles(folderPath);

				foreach (string file in files)
				{
					// Read the JSON file into a string
					var JsonString = System.IO.File.ReadAllText(file);
					// Deserialize the JSON string into a list of strings
					var Links = JsonConvert.DeserializeObject<List<string>>(JsonString);

					for (int g = 0; g < Links.Count; g++)
					{
						var Link = Links[g];

						var extractedText = ExtractTextBetween(Link, '\"', '\"');
						Console.WriteLine(extractedText);

						var filename = ExtractTextBetween(Link, '>', '<');
						Console.WriteLine(filename);

						// Sanitize the filename
						filename = SanitizeFilename(filename);
						Console.WriteLine($"Trimmed and sanitized filename: {filename}");

						await page.GoToAsync($"https://tms.adp.com{extractedText}");
						await page.WaitForTimeoutAsync(5000);

						// Define the JavaScript code to evaluate
						var otherLinks = @"
				        Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
				            .map(a => a.outerHTML)
				    ";
						var childLinks = await page.EvaluateExpressionAsync<string[]>(otherLinks);

						string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);

						string[] parts = fileNameWithoutExtension.Split('_');
						// Define the output file path
						var childPath = $@"{folderPath}/Second/{fileNameWithoutExtension}_{filename}.json";
						//var childPath = $@"F:\IT Company\Solutions\GenericCompany\bin\Debug\ykta\{fileNameWithoutExtension}_{filename}.json";

						// Serialize the elements to JSON
						var childjson = JsonConvert.SerializeObject(childLinks, Formatting.Indented);
						System.IO.File.WriteAllText(childPath, childjson);
						Console.WriteLine($"Json file {g} written");
					}
				}


				//PART 5, Again, filter json files for lines we will need
				var folderPath2 = $@"{folderPath}/Second";

				// Get all JSON files in the folder
				var jsonFiles2 = Directory.GetFiles(folderPath2, "*.json");

				//CLEAN FILES
				foreach (var jsonFile2 in jsonFiles2)
				{
					// Read the content of the file
					string jsonContent2 = System.IO.File.ReadAllText(jsonFile2);
					// Deserialize the JSON content to a list of strings
					var linez = JsonConvert.DeserializeObject<List<string>>(jsonContent2);
					// Filter lines based on the specified pattern
					var filteredLines2 = FilterLines(linez);
					// Serialize the filtered lines back to JSON
					string filteredJson2 = JsonConvert.SerializeObject(filteredLines2, Formatting.Indented);

					System.IO.File.WriteAllText(jsonFile2, filteredJson2);
					Console.WriteLine($"Processed file: {jsonFile2}");
				}

				////PART 6 FIND OTHER FOLDERS
				string[] files2 = Directory.GetFiles(folderPath2);

				foreach (string file2 in files2)
				{
					// Read the JSON file into a string
					var JsonString = System.IO.File.ReadAllText(file2);
					// Deserialize the JSON string into a list of strings
					var Links = JsonConvert.DeserializeObject<List<string>>(JsonString);

					for (int k = 0; k < Links.Count; k++)
					{
						var Link = Links[k];

						var extractedText = ExtractTextBetween(Link, '\"', '\"');
						Console.WriteLine(extractedText);

						var filename = ExtractTextBetween(Link, '>', '<');
						Console.WriteLine(filename);

						// Sanitize the filename
						filename = SanitizeFilename(filename);
						Console.WriteLine($"Trimmed and sanitized filename: {filename}");

						await page.GoToAsync($"https://tms.adp.com{extractedText}");
						await page.WaitForTimeoutAsync(5000);

						// Define the JavaScript code to evaluate
						var otherLinks = @"
				        Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
				            .map(a => a.outerHTML)
				    ";
						var childLinks = await page.EvaluateExpressionAsync<string[]>(otherLinks);

						string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file2);

						string[] parts = fileNameWithoutExtension.Split('_');
						// Define the output file path
						var childPath = $@"{folderPath}/Third/{fileNameWithoutExtension}_{filename}.json";
						//var childPath = $@"F:\IT Company\Solutions\GenericCompany\bin\Debug\ykta\{fileNameWithoutExtension}_{filename}.json";

						// Serialize the elements to JSON
						var childjson = JsonConvert.SerializeObject(childLinks, Formatting.Indented);
						System.IO.File.WriteAllText(childPath, childjson);
						Console.WriteLine($"Json file {k} written");
					}
				}

				//PART 7, CLEAN UP THIRD FOLDER
				var folderPath3 = $@"{folderPath}/Third";

				var jsonFiles3 = Directory.GetFiles(folderPath3, "*.json");

				foreach (var jsonFile3 in jsonFiles3)
				{
					// Read the content of the file
					string jsonContent3 = System.IO.File.ReadAllText(jsonFile3);
					// Deserialize the JSON content to a list of strings
					var linez = JsonConvert.DeserializeObject<List<string>>(jsonContent3);
					// Filter lines based on the specified pattern
					var filteredLines3 = FilterLines(linez);
					// Serialize the filtered lines back to JSON
					string filteredJson3 = JsonConvert.SerializeObject(filteredLines3, Formatting.Indented);

					System.IO.File.WriteAllText(jsonFile3, filteredJson3);
					Console.WriteLine($"Processed file: {jsonFile3}");
				}
				////PART 8 FIND OTHER FOLDERS
				string[] files3 = Directory.GetFiles(folderPath3);

				foreach (string file3 in files3)
				{
					// Read the JSON file into a string
					var JsonString = System.IO.File.ReadAllText(file3);
					// Deserialize the JSON string into a list of strings
					var Links = JsonConvert.DeserializeObject<List<string>>(JsonString);

					for (int m = 0; m < Links.Count; m++)
					{
						var Link = Links[m];

						var extractedText = ExtractTextBetween(Link, '\"', '\"');
						Console.WriteLine(extractedText);

						var filename = ExtractTextBetween(Link, '>', '<');
						Console.WriteLine(filename);

						// Sanitize the filename
						filename = SanitizeFilename(filename);
						Console.WriteLine($"Trimmed and sanitized filename: {filename}");

						await page.GoToAsync($"https://tms.adp.com{extractedText}");
						await page.WaitForTimeoutAsync(5000);

						// Define the JavaScript code to evaluate
						var otherLinks = @"
				        Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
				            .map(a => a.outerHTML)
				    ";
						var childLinks = await page.EvaluateExpressionAsync<string[]>(otherLinks);

						string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file3);

						string[] parts = fileNameWithoutExtension.Split('_');
						// Define the output file path
						var childPath = $@"{folderPath}/Fourth/{fileNameWithoutExtension}_{filename}.json";
						//var childPath = $@"F:\IT Company\Solutions\GenericCompany\bin\Debug\ykta\{fileNameWithoutExtension}_{filename}.json";

						// Serialize the elements to JSON
						var childjson = JsonConvert.SerializeObject(childLinks, Formatting.Indented);
						System.IO.File.WriteAllText(childPath, childjson);
						Console.WriteLine($"Json file {m} written");
					}
				}
				//PART 9, CLEAN UP FOURTH FOLDER
				var folderPath4 = $@"{folderPath}/Fourth";

				var jsonFiles4 = Directory.GetFiles(folderPath4, "*.json");

				foreach (var jsonFile4 in jsonFiles4)
				{
					// Read the content of the file
					string jsonContent4 = System.IO.File.ReadAllText(jsonFile4);
					// Deserialize the JSON content to a list of strings
					var linez = JsonConvert.DeserializeObject<List<string>>(jsonContent4);
					// Filter lines based on the specified pattern
					var filteredLines4 = FilterLines(linez);
					// Serialize the filtered lines back to JSON
					string filteredJson4 = JsonConvert.SerializeObject(filteredLines4, Formatting.Indented);

					System.IO.File.WriteAllText(jsonFile4, filteredJson4);
					Console.WriteLine($"Processed file: {jsonFile4}");
				}

				//PART 10 FIND OTHER FOLDERS
				string[] files4 = Directory.GetFiles(folderPath4);

				foreach (string file4 in files4)
				{
					// Read the JSON file into a string
					var JsonString = System.IO.File.ReadAllText(file4);
					// Deserialize the JSON string into a list of strings
					var Links = JsonConvert.DeserializeObject<List<string>>(JsonString);

					for (int n = 0; n < Links.Count; n++)
					{
						var Link = Links[n];

						var extractedText = ExtractTextBetween(Link, '\"', '\"');
						Console.WriteLine(extractedText);

						var filename = ExtractTextBetween(Link, '>', '<');
						Console.WriteLine(filename);

						// Sanitize the filename
						filename = SanitizeFilename(filename);
						Console.WriteLine($"Trimmed and sanitized filename: {filename}");

						await page.GoToAsync($"https://tms.adp.com{extractedText}");
						await page.WaitForTimeoutAsync(5000);

						// Define the JavaScript code to evaluate
						var otherLinks = @"
				        Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
				            .map(a => a.outerHTML)
				    ";
						var childLinks = await page.EvaluateExpressionAsync<string[]>(otherLinks);

						string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file4);

						string[] parts = fileNameWithoutExtension.Split('_');
						// Define the output file path
						var childPath = $@"{folderPath}/Fifth/{fileNameWithoutExtension}_{filename}.json";
						//var childPath = $@"F:\IT Company\Solutions\GenericCompany\bin\Debug\ykta\{fileNameWithoutExtension}_{filename}.json";

						// Serialize the elements to JSON
						var childjson = JsonConvert.SerializeObject(childLinks, Formatting.Indented);
						System.IO.File.WriteAllText(childPath, childjson);
						Console.WriteLine($"Json file {n} written");
					}
				}


				////PART 11 now that we have all folders, look for files
				string[] folderFiles = Directory.GetFiles(folderPath);

				foreach (string folderFile in folderFiles)
				{
					// Read the JSON file into a string
					var FolderJsonString = System.IO.File.ReadAllText(folderFile);
					// Deserialize the JSON string into a list of strings
					var docs = JsonConvert.DeserializeObject<List<string>>(FolderJsonString);

					for (int h = 0; h < docs.Count; h++)
					{
						var doc = docs[h];

						var folder = ExtractTextBetween(doc, '\"', '\"');
						Console.WriteLine(folder);

						var folderFilename = ExtractTextBetween(doc, '>', '<');
						Console.WriteLine(folderFilename);

						// Sanitize the filename
						folderFilename = SanitizeFilename(folderFilename);
						Console.WriteLine($"Trimmed and sanitized filename: {folderFilename}");

						//go to link in folder
						await page.GoToAsync($"https://tms.adp.com{folder}");
						await page.WaitForTimeoutAsync(5000);

						// Get all path and filename pairs from the page
						var pairs = await page.EvaluateFunctionAsync<List<Dictionary<string, string>>>(@"
                    () => {
                        const pairs = [];
                        const pathInputs = document.querySelectorAll('input[name^=PATH]');
                        pathInputs.forEach(input => {
                            const pathValue = input.value;
                            const index = input.name.slice(4);
                            const filenameInput = document.querySelector(`input[name=FILENAME${index}]`);
                            if (filenameInput) {
                                const filenameValue = filenameInput.value;
                                pairs.push({ pathValue, filenameValue });
                            }
                        });
                        return pairs;
                    }
                ");

						foreach (var pair in pairs)
						{
							string pathValue = pair["pathValue"];
							string nameValue = pair["filenameValue"];

							Console.WriteLine($"Path Value: {pathValue}");
							Console.WriteLine($"Filename Value: {nameValue}");
							nameValue = SanitizeFilename(nameValue);
							Console.WriteLine($"Trimmed and sanitized filename: {nameValue}");

							var downloadUrl = $"https://tms.adp.com{pathValue}";

							var pdfData = await page.EvaluateFunctionAsync<string>(@"
                            async (url) => {
                                const response = await fetch(url);
                                const blob = await response.blob();
                                return new Promise((resolve, reject) => {
                                    const reader = new FileReader();
                                    reader.onloadend = () => resolve(reader.result);
                                    reader.onerror = reject;
                                    reader.readAsDataURL(blob);
                                });
                            }", downloadUrl);

							//Save the base64 image data to a file
							var base64Data = pdfData.Split(',')[1];

							string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(folderFile);
							string newFilename = $"{fileNameWithoutExtension}_{folderFilename}_{nameValue}.pdf";
							//string newFilename = $"YKTA_{fileNameWithoutExtension}_{folderFilename}_{nameValue}.pdf";



							string outDir = @$"{folderPath}/Pdf";
							string newFilePath = System.IO.Path.Combine(outDir, newFilename);
							System.IO.File.WriteAllBytes(newFilePath, Convert.FromBase64String(base64Data));
							Console.WriteLine("Downloaded");
						}

					}
				}
				string[] folderFiles2 = Directory.GetFiles(folderPath2);

				foreach (string folderFile2 in folderFiles2)
				{
					// Read the JSON file into a string
					var FolderJsonString2 = System.IO.File.ReadAllText(folderFile2);
					// Deserialize the JSON string into a list of strings
					var docs = JsonConvert.DeserializeObject<List<string>>(FolderJsonString2);

					for (int h = 0; h < docs.Count; h++)
					{
						var doc = docs[h];

						var folder = ExtractTextBetween(doc, '\"', '\"');
						Console.WriteLine(folder);

						var folderFilename = ExtractTextBetween(doc, '>', '<');
						Console.WriteLine(folderFilename);

						// Sanitize the filename
						folderFilename = SanitizeFilename(folderFilename);
						Console.WriteLine($"Trimmed and sanitized filename: {folderFilename}");

						//go to link in folder
						await page.GoToAsync($"https://tms.adp.com{folder}");
						await page.WaitForTimeoutAsync(5000);

						// Get all path and filename pairs from the page
						var pairs = await page.EvaluateFunctionAsync<List<Dictionary<string, string>>>(@"
                    () => {
                        const pairs = [];
                        const pathInputs = document.querySelectorAll('input[name^=PATH]');
                        pathInputs.forEach(input => {
                            const pathValue = input.value;
                            const index = input.name.slice(4);
                            const filenameInput = document.querySelector(`input[name=FILENAME${index}]`);
                            if (filenameInput) {
                                const filenameValue = filenameInput.value;
                                pairs.push({ pathValue, filenameValue });
                            }
                        });
                        return pairs;
                    }
                ");

						foreach (var pair in pairs)
						{
							string pathValue = pair["pathValue"];
							string nameValue = pair["filenameValue"];

							Console.WriteLine($"Path Value: {pathValue}");
							Console.WriteLine($"Filename Value: {nameValue}");
							nameValue = SanitizeFilename(nameValue);
							Console.WriteLine($"Trimmed and sanitized filename: {nameValue}");

							var downloadUrl = $"https://tms.adp.com{pathValue}";

							var pdfData = await page.EvaluateFunctionAsync<string>(@"
                            async (url) => {
                                const response = await fetch(url);
                                const blob = await response.blob();
                                return new Promise((resolve, reject) => {
                                    const reader = new FileReader();
                                    reader.onloadend = () => resolve(reader.result);
                                    reader.onerror = reject;
                                    reader.readAsDataURL(blob);
                                });
                            }", downloadUrl);

							//Save the base64 image data to a file
							var base64Data = pdfData.Split(',')[1];

							string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(folderFile2);
							string newFilename = $"{fileNameWithoutExtension}_{folderFilename}_{nameValue}.pdf";

							string outDir = @$"{folderPath}/Pdf";
							string newFilePath = System.IO.Path.Combine(outDir, newFilename);
							System.IO.File.WriteAllBytes(newFilePath, Convert.FromBase64String(base64Data));
							Console.WriteLine("Downloaded");
						}

					}
				}

				string[] folderFiles3 = Directory.GetFiles(folderPath3);

				foreach (string folderFile3 in folderFiles3)
				{
					// Read the JSON file into a string
					var FolderJsonString3 = System.IO.File.ReadAllText(folderFile3);
					// Deserialize the JSON string into a list of strings
					var docs = JsonConvert.DeserializeObject<List<string>>(FolderJsonString3);

					for (int h = 0; h < docs.Count; h++)
					{
						var doc = docs[h];

						var folder = ExtractTextBetween(doc, '\"', '\"');
						Console.WriteLine(folder);

						var folderFilename = ExtractTextBetween(doc, '>', '<');
						Console.WriteLine(folderFilename);

						// Sanitize the filename
						folderFilename = SanitizeFilename(folderFilename);
						Console.WriteLine($"Trimmed and sanitized filename: {folderFilename}");

						//go to link in folder
						await page.GoToAsync($"https://tms.adp.com{folder}");
						await page.WaitForTimeoutAsync(5000);

						// Get all path and filename pairs from the page
						var pairs = await page.EvaluateFunctionAsync<List<Dictionary<string, string>>>(@"
                    () => {
                        const pairs = [];
                        const pathInputs = document.querySelectorAll('input[name^=PATH]');
                        pathInputs.forEach(input => {
                            const pathValue = input.value;
                            const index = input.name.slice(4);
                            const filenameInput = document.querySelector(`input[name=FILENAME${index}]`);
                            if (filenameInput) {
                                const filenameValue = filenameInput.value;
                                pairs.push({ pathValue, filenameValue });
                            }
                        });
                        return pairs;
                    }
                ");

						foreach (var pair in pairs)
						{
							string pathValue = pair["pathValue"];
							string nameValue = pair["filenameValue"];

							Console.WriteLine($"Path Value: {pathValue}");
							Console.WriteLine($"Filename Value: {nameValue}");
							nameValue = SanitizeFilename(nameValue);
							Console.WriteLine($"Trimmed and sanitized filename: {nameValue}");

							var downloadUrl = $"https://tms.adp.com{pathValue}";

							var pdfData = await page.EvaluateFunctionAsync<string>(@"
                            async (url) => {
                                const response = await fetch(url);
                                const blob = await response.blob();
                                return new Promise((resolve, reject) => {
                                    const reader = new FileReader();
                                    reader.onloadend = () => resolve(reader.result);
                                    reader.onerror = reject;
                                    reader.readAsDataURL(blob);
                                });
                            }", downloadUrl);

							//Save the base64 image data to a file
							var base64Data = pdfData.Split(',')[1];

							string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(folderFile3);
							string newFilename = $"{fileNameWithoutExtension}_{folderFilename}_{nameValue}.pdf";

							string outDir = @$"{folderPath}/Pdf";
							string newFilePath = System.IO.Path.Combine(outDir, newFilename);
							System.IO.File.WriteAllBytes(newFilePath, Convert.FromBase64String(base64Data));
							Console.WriteLine("Downloaded");
						}

					}
				}

				string[] folderFiles4 = Directory.GetFiles(folderPath4);

				foreach (string folderFile4 in folderFiles4)
				{
					// Read the JSON file into a string
					var FolderJsonString4 = System.IO.File.ReadAllText(folderFile4);
					// Deserialize the JSON string into a list of strings
					var docs = JsonConvert.DeserializeObject<List<string>>(FolderJsonString4);

					for (int h = 0; h < docs.Count; h++)
					{
						var doc = docs[h];

						var folder = ExtractTextBetween(doc, '\"', '\"');
						Console.WriteLine(folder);

						var folderFilename = ExtractTextBetween(doc, '>', '<');
						Console.WriteLine(folderFilename);

						// Sanitize the filename
						folderFilename = SanitizeFilename(folderFilename);
						Console.WriteLine($"Trimmed and sanitized filename: {folderFilename}");

						//go to link in folder
						await page.GoToAsync($"https://tms.adp.com{folder}");
						await page.WaitForTimeoutAsync(5000);

						// Get all path and filename pairs from the page
						var pairs = await page.EvaluateFunctionAsync<List<Dictionary<string, string>>>(@"
                    () => {
                        const pairs = [];
                        const pathInputs = document.querySelectorAll('input[name^=PATH]');
                        pathInputs.forEach(input => {
                            const pathValue = input.value;
                            const index = input.name.slice(4);
                            const filenameInput = document.querySelector(`input[name=FILENAME${index}]`);
                            if (filenameInput) {
                                const filenameValue = filenameInput.value;
                                pairs.push({ pathValue, filenameValue });
                            }
                        });
                        return pairs;
                    }
                ");

						foreach (var pair in pairs)
						{
							string pathValue = pair["pathValue"];
							string nameValue = pair["filenameValue"];

							Console.WriteLine($"Path Value: {pathValue}");
							Console.WriteLine($"Filename Value: {nameValue}");
							nameValue = SanitizeFilename(nameValue);
							Console.WriteLine($"Trimmed and sanitized filename: {nameValue}");

							var downloadUrl = $"https://tms.adp.com{pathValue}";

							var pdfData = await page.EvaluateFunctionAsync<string>(@"
                            async (url) => {
                                const response = await fetch(url);
                                const blob = await response.blob();
                                return new Promise((resolve, reject) => {
                                    const reader = new FileReader();
                                    reader.onloadend = () => resolve(reader.result);
                                    reader.onerror = reject;
                                    reader.readAsDataURL(blob);
                                });
                            }", downloadUrl);

							//Save the base64 image data to a file
							var base64Data = pdfData.Split(',')[1];

							string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(folderFile4);
							string newFilename = $"{fileNameWithoutExtension}_{folderFilename}_{nameValue}.pdf";

							string outDir = @$"{folderPath}/Pdf";
							string newFilePath = System.IO.Path.Combine(outDir, newFilename);
							System.IO.File.WriteAllBytes(newFilePath, Convert.FromBase64String(base64Data));
							Console.WriteLine("Downloaded");
						}

					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			// Method to extract text between two characters
			static string ExtractTextBetween(string text, char startChar, char endChar)
			{
				int startIndex = text.IndexOf(startChar) + 1; // Get the index right after startChar
				int endIndex = text.IndexOf(endChar, startIndex); // Get the index of endChar after startIndex
				if (startIndex > 0 && endIndex > startIndex)
				{
					return text.Substring(startIndex, endIndex - startIndex);
				}
				return string.Empty; // Return empty string if no valid text is found
			}

			static string SanitizeFilename(string filename)
			{
				// Replace / with an underscore or any other character you prefer

				return filename.Replace("/", "")
				.Replace("amp", "")
				.Replace(",", "")
				.Replace(";", "")
				.Replace("'", "")
				.Replace(":", "")
				.Replace("?", "")
				.Replace("\\", "")
				.Replace("*", "")
				.Replace(">", "")
				.Replace("<", "")
				.Replace("|", "")
				.Replace("_", " ")
				.Replace('"', ' ')
				.Replace("  ", " ");
			}
			static List<string> FilterLines(List<string> lines)
			{
				// Define the regex pattern to match lines with words between carets
				string pattern = @"<a href=\""/lms/servlet/lms/FRFILE\?RID=[^\""]+\"">[^<]+</a>";

				var regex = new Regex(pattern, RegexOptions.Compiled);

				var filteredLines = new List<string>();

				foreach (var line in lines)
				{
					if (regex.IsMatch(line))
					{
						filteredLines.Add(line);
					}
				}

				return filteredLines;
			}
		}

		static async Task renameLMSPdf()
		{
			try
			{
				var page = (await browser.PagesAsync()).First();

				var folderPath = @"F:\IT Company\GenericCompany\EmployeeDocuments\YKTA";
				var outpath = @"F:\IT Company\GenericCompany\EmployeeDocuments\YKTA\rename";
				string[] folderFiles = Directory.GetFiles(folderPath);

				foreach (string folderFile in folderFiles)
				{
					string nameNoExt = System.IO.Path.GetFileName(folderFile);
					string newFilename = $"GC_LMS_{nameNoExt}";
					string newFilePath = System.IO.Path.Combine(outpath, newFilename);
					System.IO.File.Copy(folderFile, newFilePath);
					Console.WriteLine("Renamed: " + newFilename);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		//for Pay Summaries
		static async Task JsonToHtml()
		{
			try
			{
				var page = await browser.NewPageAsync();
				await page.GoToAsync("https://workforcenow.adp.com/theme/admin.html#/People/PeopleTabPayProfile");
				await page.WaitForTimeoutAsync(5000);

				string inputDirectory = @"C:\Temp\Testing\GenericCompany\PaySumJson";
				string outputDirectory = @"C:\Temp\Testing\GenericCompany\PaySumHTML";
				//string inputDirectory = @"C:\Temp\Testing\ECHA Output\ArchivedDetailSummaries";
				//string outputDirectory = @"C:\Temp\Testing\ECHA Output\ArchivedHTML";

				string[] files = Directory.GetFiles(inputDirectory);

				foreach (string file in files)
				{
					DetailRoot p = new DetailRoot();
					string detailData = System.IO.File.ReadAllText(file);
					try
					{
						p = JsonConvert.DeserializeObject<DetailRoot>(detailData);

					}
					catch (Exception ex)
					{
						Console.WriteLine("Error: " + ex.Message);
					}

					var psData = new PayStatement2();
					var psCount = p.data.payStatement.checkGrossPayAmt.Count();
					//Console.WriteLine(psCount);
					if (psCount == 0)
					{
						string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);
						Console.WriteLine("No pay summaries for " + fileNameWithoutExtension);
					}
					else
					{
						//foreach (PayStatement summary in summarys.data.payStatementList)
						for (int i = 0; i < psCount; i++)
						{
							psData = p.data.payStatement;

							string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);
							Console.WriteLine(fileNameWithoutExtension);
							string fileName = System.IO.Path.GetFileName(file);

							string[] parts = fileNameWithoutExtension.Split('_');

							var paycom = parts[0];
							var aoid = parts[1];
							var coCode = parts[2];
							var lastName = parts[3];
							var firstName = parts[4];
							var lastFour = parts[5];
							var positionId = parts[6];
							var empId = parts[7];
							var payDate = parts[8];
							var checkNumber = parts[9];
							var oid = parts[10];
							var yearWeekPayroll = parts[11];

							string grossPay = p.data.payStatement.checkGrossPayAmt;
							// Find the index of the decimal point
							int decimalIndex = grossPay.IndexOf('.');

							// If a decimal point exists and there are more than two digits after it
							if (decimalIndex != -1 && grossPay.Length > decimalIndex + 3)
							{
								// Keep only two digits after the decimal point
								grossPay = grossPay.Substring(0, decimalIndex + 3);
							}

							string newFileName = paycom + "_" + empId + "_GC_" + lastName + "_" + firstName + "_" + psData.checkNumber + "_" + psData.payDate + "_PaySummary.html";

							var sHtmlOut = "";

							sHtmlOut = $"<html version=\"1.0\" encoding=\"UTF-8\"><font-size: 12px; font: Tahoma>"
								+ $"<!DOCTYPE html>\r\n<html>\r\n"
								+ $"<head>\r\n"
								+ $"<style>\r\n"
								+ $".grid2-container {{\r\n  display: grid;\r\n  grid-template-columns: auto auto;\r\n  background-color: #ffffff;\r\n}}\r\n"
								+ $".grid-itemL {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: left;\r\n}}\r\n"
								+ $".grid-itemR {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: right;\r\n}}\r\n"
								+ $".grid3-container {{\r\n  display: grid;\r\n  grid-template-columns: 35% 35% 30%;\r\n  background-color: #ffffff;\r\n}}\r\n"
								+ $".grid-itemL {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: left;\r\n}}\r\n"
								+ $".grid-itemC {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: center;\r\n}}\r\n"
								+ $".grid-itemR {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: right;\r\n}}\r\n"
								+ $"</style>\r\n"
								+ $"</head>\r\n"
								+ $"<body>\r\n";

							sHtmlOut = sHtmlOut + $"<table cellpadding=2 cellspacing=0 style='border:0px solid black; font-size:10px; font:Tahoma;'>\r\n"
								+ $"<tr>\r\n"
									+ $"<td style='width:33%; text-align:left; font-size:18px; font-weight:bold;'>Pay Summary:&nbsp;{p.data.payStatement.year}-{p.data.payStatement.week}-{p.data.payStatement.payrollNumber}</td>"
									+ $"<td style='width:40%; text-align:center; font-size:10px;'>This summary is a record of a payment issued and not an image of the actual pay statement.</td>"
									+ $"<td style='width:25%; text-align:right; font-size:12px;'>{DateTime.Now}</td>"
								+ $"</tr>"
								+ $"<tr>\r\n"
									+ $"<td style='width:30%; text-align:left; font-size:18px; font-weight:bold;'>&nbsp;</td>"
									+ $"<td style='width:35%; text-align:center; font-size:10px;'>&nbsp;</td>"
									+ $"<td style='width:30%; text-align:right; font-size:12px;'>&nbsp;</td>"
								+ $"</tr>"
								+ $"<tr>\r\n"
																					+ $"<td style='width:30%; text-align:left; '>"
														+ $"<table cellpadding=2 cellspacing=0 style='border:1px solid black; font-size:10px;' >"
														//+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;'>&nbsp;EIN&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{p.data.payStatement.companyMailLabel}&nbsp;</td>\r\n</tr>\r\n"
														+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;'>&nbsp;Co.&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{p.data.payStatement.companyCode}&nbsp;</td>\r\n</tr>\r\n"
														+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;'>&nbsp;Home Dept&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{p.data.payStatement.homeDepartment}&nbsp;</td>\r\n</tr>\r\n"
														+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;'>&nbsp;Worked In Dept&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{p.data.payStatement.workedInDepartment}&nbsp;</td>\r\n</tr>\r\n"
														+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;'>&nbsp;Clock&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{p.data.payStatement.clock}&nbsp;</td>\r\n</tr>\r\n"
														//+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;'>&nbsp;Paycom ID&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{pcID.Replace("0000", "n/a")}&nbsp;</td>\r\n</tr>\r\n"
														//+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;'>&nbsp;SSN Last 4&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{(string.IsNullOrWhiteSpace(empX.SS_Number) ? "" : (string.IsNullOrWhiteSpace(empX.SS_Number) ? "" : empX.SS_Number.Replace("-", "").Substring(5)))}&nbsp;</td>\r\n</tr>\r\n"
														//+ $"<tr>\r\n<td style='border-top:1px solid black;text-align:right;background-color:#CCCCCC;'>&nbsp;Status&nbsp;</td>\r\n"
														//+ $"<td style='border-top:1px solid black;border-left:1px solid black'>&nbsp;{emp.positions[0].status}&nbsp;</td>\r\n</tr>\r\n"
														+ $"</table>\r\n"
													+ $"</td>"
															+ $"<td style='width:35%; text-align:center;'>"
														+ $"<div style='font-size:14px;font-weight:bold;'>{(string.IsNullOrEmpty(p.data.payStatement.mailLabel) ? "No Mailing Label" : p.data.payStatement.mailLabel.Replace("\n", "<br />"))}</div>"
													+ $"</td>"
													+ $"<td style='width:30%; text-align:right;'>"
														+ $"<div style='font-size:14px;'>{(string.IsNullOrEmpty(p.data.payStatement.companyMailLabel) ? "No Mailing Label" : p.data.payStatement.companyMailLabel.Replace("\n", "<br />"))}</div>"
													+ $"</td>"
												+ $"</tr>"
											+ $"</table><br />";

							sHtmlOut = sHtmlOut + $"<table width=100% style='border:1px solid black;font-size:12px; font:Tahoma;'>\r\n"
								+ $"<tr width='100%'>\r\n"
									+ $"<td align='center' width='10%'><b>Period Start Date</b>&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'><b>Period End Date</b>&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'><b>Pay Date</b>&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'><b>File #</b>&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'><b>Check/Voucher #</b>&nbsp;</td>\r\n"
								+ $"</tr>\r\n"
								+ $"<tr width='100%'>\r\n"
									+ $"<td align='center' width='10%'>{p.data.payStatement.periodStartDateFormattedStr}&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'>{(string.IsNullOrEmpty(p.data.payStatement.periodEndDateFormattedStr) ? "" : p.data.payStatement.periodEndDateFormattedStr)}&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'>{(string.IsNullOrEmpty(p.data.payStatement.payDateFormattedStr) ? "" : p.data.payStatement.payDateFormattedStr)}&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'>{(string.IsNullOrEmpty(p.data.payStatement.fileNumber) ? "" : p.data.payStatement.fileNumber)}&nbsp;</td>\r\n"
									+ $"<td align='center' width='10%'>{(string.IsNullOrEmpty(p.data.payStatement.checkNumber) ? "" : p.data.payStatement.checkNumber)}&nbsp;</td>\r\n"
								+ $"</tr>\r\n"
							+ $"</table>\r\n"
							+ $"<br />";
							/************Gross Pay*********

							if (p.data.payStatement.hoursEarningsRateList != null)
							{
								sHtmlOut = sHtmlOut + $"<table width=100% style='border-left:5px solid LightGreen; font-size:14px; font:Tahoma;'>\r\n"
													+ $"<tr>\r\n"
														+ $"<td align='left' style='font-size:16px; width:20%;'><b>&nbsp;Gross Pay</b></td>"
														+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
														+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
														+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
														+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
														+ $"<td align='right' style='font-size:16px' width:20%;'><b>&nbsp;$&nbsp;{grossPay}</b></td>\r\n"
													+ $"</tr>\r\n";

								for (int z = 0; z < p.data.payStatement.hoursEarningsRateList.Count; z++)
								{
									if (string.IsNullOrEmpty(p.data.payStatement.hoursEarningsRateList[z].earnings)) { continue; }
									var desc = p.data.payStatement.hoursEarningsRateList[z].description;
									if (!string.IsNullOrEmpty(p.data.payStatement.hoursEarningsRateList[z].fieldNumber))
									{
										desc = desc + " (field " + p.data.payStatement.hoursEarningsRateList[z].fieldNumber + ")";
									}
									var rateLbl = "";
									var rate = "";
									if (!string.IsNullOrEmpty(p.data.payStatement.hoursEarningsRateList[z].displayRate))
									{
										rateLbl = "Rate:";
										rate = p.data.payStatement.hoursEarningsRateList[z].displayRate;
									}
									var hoursLbl = "";
									var hours = "";


									sHtmlOut = sHtmlOut + $"<tr>\r\n"
																	+ $"<td align='left' style='border-left:10px; border-top:1px solid darkgray; font-size:12px; width:20%;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{desc}</td>"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{rateLbl}</td>"
																	+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{rate}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{hoursLbl}</td>"
														+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{hours}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:20%;'><b>&nbsp;$&nbsp;{psData.hoursEarningsRateList[z].earnings}</b></td>"

																+ $"</tr>\r\n";
								}
							}
							if (!string.IsNullOrEmpty(p.data.payStatement.totalHoursWorked))
							{
								sHtmlOut = sHtmlOut + $"<tr>"
																+ $"<td align='left' style='border-top:0px solid darkgray; font-size:14px; width:20%;'><b>Total Hours Worked:&nbsp;{p.data.payStatement.totalHoursWorked}</b></td>\r\n"
																	+ $"<td align='right' style='border-top:0px solid darkgray; font-size:12px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='border-top:0px solid darkgray; font-size:12px; width:16%;'>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='border-top:0px solid darkgray; font-size:12px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='border-top:0px solid darkgray; font-size:12px; width:16%;'>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='border-top:0px solid darkgray; font-size:12px; width:20%;'><b>&nbsp;</b></td>"
															+ $"</tr>\r\n";
							}

							if (!string.IsNullOrEmpty(p.data.payStatement.basisOfPay))
							{
								sHtmlOut = sHtmlOut + $"<tr>"
																+ $"<td align='left' style='border-top:0px solid darkgray; font-size:14px; width:20%;'><b>Basis of Pay:&nbsp;{p.data.payStatement.basisOfPay}</b></td>\r\n"
																	+ $"<td align='right' style='border-top:0px solid darkgray; font-size:12px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='border-top:0px solid darkgray; font-size:12px; width:16%;'>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='border-top:0px solid darkgray; font-size:12px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='border-top:0px solid darkgray; font-size:12px; width:16%;'>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='border-top:0px solid darkgray; font-size:12px; width:20%;'><b>&nbsp;</b></td>"
															+ $"</tr>\r\n";
							}
							sHtmlOut = sHtmlOut + $"</table>\r\n<br />";
							/********************Taxes*****************
							if (p.data.payStatement.taxDeductionsList != null && p.data.payStatement.taxDeductionsList.Count() > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=100% style='border-left:5px solid DarkOrange; font-size:14px; font:Tahoma;'>\r\n"
																+ $"<tr>\r\n"
																	+ $"<td align='left' style='font-size:16px; width:20%;'><b>&nbsp;Taxes</b></td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px' width:20%;'><b>&nbsp;$&nbsp;{p.data.payStatement.totalTax}</b></td>\r\n"
																+ $"</tr>\r\n";

								for (int z = 0; z < p.data.payStatement.taxDeductionsList.Count; z++)
								{
									if (string.IsNullOrEmpty(p.data.payStatement.taxDeductionsList[z].amount)) { continue; }

									var code = p.data.payStatement.taxDeductionsList[z].code;
									var codeDesc = p.data.payStatement.taxDeductionsList[z].codeAndDesc;
									var desc = p.data.payStatement.taxDeductionsList[z].description;

									var rateLbl = "";
									var rate = "";
									var hoursLbl = "";
									var hours = "";

									if (!string.IsNullOrEmpty(code) && code != " ")
									{
										desc = p.data.payStatement.taxDeductionsList[z].codeAndDesc;
										rateLbl = "Code:";
										rate = p.data.payStatement.taxDeductionsList[z].code;
									}
									sHtmlOut = sHtmlOut + $"<tr>\r\n"
																	+ $"<td align='left' style='border-left:10px; border-top:1px solid darkgray; font-size:12px; width:20%;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{desc}</td>"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{rateLbl}</td>"
																	+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{rate}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{hoursLbl}</td>"
																	+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{hours}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:20%;'><b>&nbsp;$&nbsp;{p.data.payStatement.taxDeductionsList[z].amount}</b></td>"
																+ $"</tr>\r\n";
								}
								sHtmlOut = sHtmlOut + $"</table>\r\n<br />";
							}
							/**********Deductions**************/
							if (p.data.payStatement.otherDeductionsList != null && p.data.payStatement.otherDeductionsList.Count() > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=100% style='border-left:5px solid Red;font-size:14px;font:Tahoma;'>\r\n"
																+ $"<tr>\r\n"
																	+ $"<td align='left' style='font-size:16px; width:20%;'><b>&nbsp;Deductions</b></td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px' width:20%;'><b>&nbsp;$&nbsp;{p.data.payStatement.totalDeductionFormattedStr}</b></td>\r\n"
																+ $"</tr>\r\n";

								for (int z = 0; z < p.data.payStatement.otherDeductionsList.Count; z++)
								{
									if (string.IsNullOrEmpty(p.data.payStatement.otherDeductionsList[z].amount)) { continue; }
									var desc = p.data.payStatement.otherDeductionsList[z].codeAndDesc;
									if (string.IsNullOrEmpty(desc))
									{
										desc = "";
									}
									var rateLbl = "";
									var rate = "";
									var hoursLbl = "";
									var hours = "";
									sHtmlOut = sHtmlOut + $"<tr>\r\n"
																	+ $"<td align='left' style='border-left:10px; border-top:1px solid darkgray; font-size:12px; width:20%;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{desc}</td>"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{rateLbl}</td>"
																	+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{rate}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{hoursLbl}</td>"
																	+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{hours}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:20%;'><b>&nbsp;$&nbsp;{p.data.payStatement.otherDeductionsList[z].amount}</b></td>"
																+ $"</tr>\r\n";
								}
								sHtmlOut = sHtmlOut + $"</table>\r\n<br />";
							}
							/**********Take Home***********/
							if (p.data.payStatement.takeHomeList != null && p.data.payStatement.takeHomeList.Count() > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=100% style='border-left:5px solid Purple;font-size:14px;font:Tahoma;'>\r\n"
																+ $"<tr>\r\n"
																	+ $"<td align='left' style='font-size:16px; width:20%;'><b>&nbsp;Take Home</b></td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px' width:20%;'><b>&nbsp;$&nbsp;{p.data.payStatement.checkNetPayFormattedStr}</b></td>\r\n"
																+ $"</tr>\r\n";

								for (int z = 0; z < p.data.payStatement.takeHomeList.Count; z++)
								{
									if (string.IsNullOrEmpty(p.data.payStatement.takeHomeList[z].amount)) { continue; }

									var desc = p.data.payStatement.takeHomeList[z].description;
									var code = "";

									var rateLbl = "";
									var rate = "";
									var hoursLbl = "";
									var hours = "";

									if (string.IsNullOrEmpty(desc))
									{
										desc = "";
									}
									sHtmlOut = sHtmlOut + $"<tr>\r\n"
																	+ $"<td align='left' style='border-left:10px; border-top:1px solid darkgray; font-size:12px; width:20%;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{desc}</td>"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{rateLbl}</td>"
																	+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{rate}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{hoursLbl}</td>"
																	+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{hours}</td>\r\n"
																	+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:20%;'><b>&nbsp;$&nbsp;{p.data.payStatement.takeHomeList[z].amount}</b></td>"
																+ $"</tr>\r\n";
								}
								sHtmlOut = sHtmlOut + $"</table>\r\n<br />";
							}
							/*********Other Detail, Memos****************/

							if (p.data.payStatement.memosList != null && p.data.payStatement.memosList.Count() > 0)
							{
								sHtmlOut = sHtmlOut + $"<div class='grid2-container'>\r\n"
																+ $"<div class='grid-itemL' style='font-size:18px;font-weight:bold;'>Other Details</div><div class='grid-itemR' style='font-size:12px;'>&nbsp;</div>\r\n"
															+ $"</div>";

								sHtmlOut = sHtmlOut + $"<table width=100% style='border-left:0px solid Orange;font-size:14px;font:Tahoma;'>\r\n"
																+ $"<tr>\r\n"
																	+ $"<td align='left' style='font-size:16px; width:20%;'><b>&nbsp;Memos</b></td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px; width:12%;'>&nbsp;</td>"
																	+ $"<td align='left' style='font-size:16px; width:16%;'>&nbsp;</td>"
																	+ $"<td align='right' style='font-size:16px' width:20%;'><b>&nbsp;</b></td>\r\n"
																+ $"</tr>\r\n";

								if (p.data.payStatement.memosList != null)
								{
									for (int z = 0; z < p.data.payStatement.memosList.Count; z++)
									{
										if (string.IsNullOrEmpty(p.data.payStatement.memosList[z].amount)) { continue; }

										var desc = p.data.payStatement.memosList[z].codeAndDesc;
										var code = "";

										var rateLbl = "";
										var rate = "";
										var hoursLbl = "";
										var hours = "";

										if (string.IsNullOrEmpty(desc))
										{
											desc = "";
										}
										sHtmlOut = sHtmlOut + $"<tr>\r\n"
																		+ $"<td align='left' style='border-left:10px; border-top:1px solid darkgray; font-size:12px; width:20%;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{desc}</td>"
																		+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{rateLbl}</td>"
																		+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{rate}</td>\r\n"
																		+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:12%;'>&nbsp;{hoursLbl}</td>"
																		+ $"<td align='left' style='border-top:1px solid darkgray; font-size:12px; width:16%;'>&nbsp;{hours}</td>\r\n"
																		+ $"<td align='right' style='border-top:1px solid darkgray; font-size:12px; width:20%;'><b>&nbsp;$&nbsp;{p.data.payStatement.memosList[z].amount}</b></td>"
																	+ $"</tr>\r\n";
									}
								}
								sHtmlOut = sHtmlOut + $"</table>\r\n<br />";
							}
							sHtmlOut = sHtmlOut + $"</body></html>";

							System.IO.File.WriteAllText(System.IO.Path.Combine(outputDirectory, newFileName.Replace(".json", ".html")), sHtmlOut);
						}

					}
				}
			}
			catch (Exception ex)
			{
				// Handle exceptions gracefully
				Console.WriteLine($"An error occurred: {ex.Message}");
				// Additional error handling logic here			}
			}
		}
		//Convert json to html
		static async Task PayHistoryHtml()
		{
			try
			{
				

				var inputDirectory = @"C:\Temp\Testing\GenericCompany\PayHistoryJson";
				//var inputDirectory = @"F:\IT Company\GenericCompany\GC Pay Hist Summ Json";
				var outputDirectory = @"C:\Temp\Testing\GenericCompany\PayHistoryHtml";

				string[] files = Directory.GetFiles(inputDirectory);
				var cultureInfo = Thread.CurrentThread.CurrentCulture;
				var numberFormatInfo = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();

				//foreach (string file in files)
				for(int i = 0; i< files.Length; i++)
				{
					string file = files[i];
					PayRateHistADP p = new PayRateHistADP();

					string detailData = System.IO.File.ReadAllText(file);
					try
					{
						p = JsonConvert.DeserializeObject<PayRateHistADP>(detailData);

					}
					catch (Exception ex)
					{
						Console.WriteLine("Error: " + ex.Message);
					}

					string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);
					Console.WriteLine(fileNameWithoutExtension);
					string fileName = System.IO.Path.GetFileName(file);

					string[] parts = fileNameWithoutExtension.Split('_');

					var paycom = parts[0];
					var aoid = parts[1];
					var coCode = parts[2];
					var lastName = parts[3];
					var firstName = parts[4];
					var lastFour = parts[5];
					var positionId = parts[6];
					//var empId = parts[7];
					// Check if there are enough parts and the seventh index (empId) is not empty
					var empId = (parts.Length > 7 && !string.IsNullOrEmpty(parts[7])) ? parts[7] : "000000";
					//if (empId == null)
					//	empId = "000000";

					//string newFileName = $"{paycom}_{empId}_GC_{lastName}_{firstName}_RegularPayHistory";
					//string extention = ".html";
					//var newFileName = baseFileName + extention;


					//Console.WriteLine("New filename: " + newFileName);

					bool found = false;
					EmployeeRecordADP matchedEmployee = null;

					foreach (var emp in Emp)
					{
						if (emp.positions != null && emp.positions[0].status.Length > 0)
						{
							if (positionId == emp.positions[0].positionId)
							{
								found = true;
								matchedEmployee = emp;
								break;
							}
						}
					}


					if (found && matchedEmployee != null)
					{
						string baseFileName = $"{paycom}_{empId}_GC_{lastName}_{firstName}_{matchedEmployee.positions[0].positionId}_RegularPayHistory";
						string extention = ".html";
						var newFileName = baseFileName + extention;
						//string extention = ".html";
						//var newFileName = baseFileName + extention;


						Console.WriteLine("New filename: " + newFileName);
						var sHtmlOut = "";

						sHtmlOut = $"<html version=\"1.0\" encoding=\"UTF-8\"><font-size: 12px; font: Tahoma>"
						+ $"<!DOCTYPE html>\r\n<html>\r\n"
						+ $"<head>\r\n"
						+ $"<style>\r\n"
						+ $".grid2-container {{\r\n  display: grid;\r\n  grid-template-columns: auto auto;\r\n  background-color: #ffffff;\r\n}}\r\n"
						+ $".grid-itemL {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: left;\r\n}}\r\n"
						+ $".grid-itemR {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: right;\r\n}}\r\n"
						+ $".grid3-container {{\r\n  display: grid;\r\n  grid-template-columns: 35% 35% 30%;\r\n  background-color: #ffffff;\r\n}}\r\n"
						+ $".grid-itemL {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: left;\r\n}}\r\n"
						+ $".grid-itemC {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: center;\r\n}}\r\n"
						+ $".grid-itemR {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: right;\r\n}}\r\n"
						+ $"</style>\r\n"
						+ $"</head>\r\n"
						+ $"<body>\r\n";

						sHtmlOut = sHtmlOut + $"<table cellpadding=2 cellspacing=0 style='border:0px solid black; font-size:10px; font:Tahoma; width:100%;'>\r\n"
										+ $"<tr>\r\n<td align='center' style='font-size:18px;font-weight:bold;' width=100%>Regular Pay History Summary</td>\r\n</tr>\r\n"
										+ $"<tr>\r\n<td align='center' style='font-size:22px;' width=100%>{lastName}, {firstName}</td>\r\n</tr>\r\n"
										+ $"<tr>\r\n"
											+ $"<td align='center' style='font-size:10px;' width=100%>ADP ID: {aoid} &nbsp;&nbsp; Paycom ID: {paycom.Replace("0000", "n/a")} &nbsp;&nbsp; SSN Last 4: {lastFour} &nbsp;&nbsp; Employee Pos ID: {positionId}</td>\r\n"
										+ $"</tr>\r\n"
										+ $"<tr>\r\n<td align='center' style='font-size:10px;' width=100%>{DateTime.Now}</td>\r\n</tr>\r\n"
										+ $"<tr>\r\n"
											+ $"<td width=100%>\r\n"
												+ $"<table style='border:1px solid black;font-size:10px;' cellpadding=2 cellspacing=0>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;EIN&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].coCode}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Job Title&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].jobTitle}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Position ID&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].positionId}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Department&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].homeDepartment}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n"
														+ $"<td style='border-top:1px solid black;text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Status&nbsp;</td>\r\n"
														+ $"<td style='border-top:1px solid black;border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].status}&nbsp;</td>\r\n"
													+ $"</tr>\r\n"
												+ $"</table>\r\n"
											+ $"</td>\r\n"
										+ $"</tr>\r\n"
									+ $"</table>\r\n";
						if (p.currentList.Length + p.historyList.Length + p.futureList.Length == 0)
						{
							sHtmlOut = sHtmlOut + $"<table width=100% style='border:0px solid black;font-size:12px; font:Tahoma;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='center' style='font-size:22px;font-weight:bold;' width=100%>Employee has no Pay History</td></tr>\r\n</table>\r\n";
						}
						else
						{
							if (p.currentList.Length > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=100% style='border:0px solid black;font-size:12px; font:Tahoma;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='left' style='font-size:18px;font-weight:bold;' width=30%>Current</td></tr>\r\n</table>\r\n";

								sHtmlOut = sHtmlOut + $"<table width=100% style='border:1px solid black;font-size:12px;'>\r\n"
																+ $"<tr width='100%'>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Effective Date</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:15%;'><b>Compensation Change Reason</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Rate Type</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:10%;'><b>Amount</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:10%;'><b>Rate 2</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Pay Frequency</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:6%;'><b>Standard Hours</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:15%;'><b>Annual Salary</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:14%;'><b>Change</b>&nbsp;</td>\r\n"
																+ $"</tr>\r\n"
															+ $"</table>\r\n";

								for (int h = 0; h < p.currentList.Length; h++)
								{
									sHtmlOut = sHtmlOut + $"<table width=100% style='border:0px solid black;font-size:12px; font:Tahoma;'>\r\n"
																+ $"<tr width='100%'>\r\n"
																	+ $"<td align='left' style='width:10%;'>{p.currentList[h].Salary.key.effDate}</td>\r\n"
																	+ $"<td align='left' style='width:15%;'>{p.currentList[h].Salary.IncreaseType.code}&nbsp;-&nbsp;{p.currentList[h].Salary.IncreaseType.description}</td>\r\n"
																	+ $"<td align='left' style='width:10%;'>{(p.currentList[h].Salary.RateType != null ? (p.currentList[h].Salary.RateType.code == "S" ? "Salary" : "Hourly") : "")}</td>\r\n"
																	+ $"<td align='right' style='width:10%;'>{p.currentList[h].Salary.Rate1Amount}&nbsp;-&nbsp;{p.currentList[h].Salary.Rate1CurrencyCode}</td>\r\n"
																	+ $"<td align='right' style='width:10%;'>{p.currentList[h].Salary.Rate2Amount}&nbsp;-&nbsp;{p.currentList[h].Salary.Rate2CurrencyCode}</td>\r\n"
																	//+ $"<td align='left' style='width:10%;'>{(p.currentList[h].Salary.PayFreqType.code == "B" ? "Biweekly" : "Monthly")}</td>\r\n"
																	+$"<td align='left' style='width:10%;'>{(p.currentList[h].Salary.PayFreqType?.code == "B" ? "Biweekly" : (p.currentList[h].Salary.PayFreqType?.code == null ? "&nbsp;" : "Monthly"))}</td>\r\n"

																	+ $"<td align='right' style='width:6%;'>{p.currentList[h].Salary.StandardHours.ToString()}</td>\r\n"
																	+ $"<td align='right' style='width:15%;'>{p.currentList[h].Salary.AnnualSalaryAmount}</td>\r\n"
																	+ $"<td align='right' style='width:14%;'>{p.currentList[h].Salary.dollarChange}&nbsp;-&nbsp;{p.currentList[h].Salary.percentChange.ToString()}%</td>\r\n"
																+ $"</tr>\r\n"
															+ $"</table>\r\n";
								}
							}

							if (p.historyList.Length > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=100% style='border:0px solid black;font-size:12px; font:Tahoma;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='left' style='font-size:18px;font-weight:bold;' width=30%>History</td></tr>\r\n</table>\r\n";

								sHtmlOut = sHtmlOut + $"<table width=100% style='border:1px solid black;font-size:12px; font:Tahoma;'>\r\n"
																+ $"<tr width='100%'>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Effective Date</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:15%;'><b>Compensation Change Reason</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Rate Type</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:10%;'><b>Amount</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:10%;'><b>Rate 2</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Pay Frequency</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:6%;'><b>Standard Hours</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:15%;'><b>Annual Salary</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:14%;'><b>Change</b>&nbsp;</td>\r\n"
																+ $"</tr>\r\n"
															+ $"</table>\r\n";

								for (int h = 0; h < p.historyList.Length; h++)
								{
									sHtmlOut = sHtmlOut + $"<table width=100% style='border:0px solid black;font-size:12px; font:Tahoma;'>\r\n"
																	+ $"<tr width='100%'>\r\n"
																		+ $"<td align='left' style='width:10%;'>{p.historyList[h].Salary.key.effDate}</td>\r\n"
																		+ $"<td align='left' style='width:15%;'>{p.historyList[h].Salary.IncreaseType.code}&nbsp;-&nbsp;{p.historyList[h].Salary.IncreaseType.description}</td>\r\n"
																		+ $"<td align='left' style='width:10%;'>{(p.historyList[h].Salary.RateType != null ? (p.historyList[h].Salary.RateType.code == "S" ? "Salary" : "Hourly") : "")}</td>\r\n"
																		+ $"<td align='right' style='width:10%;'>{p.historyList[h].Salary.Rate1Amount}&nbsp;-&nbsp;{p.historyList[h].Salary.Rate1CurrencyCode}</td>\r\n"
																		+ $"<td align='right' style='width:10%;'>{p.historyList[h].Salary.Rate2Amount}&nbsp;-&nbsp;{p.historyList[h].Salary.Rate2CurrencyCode}</td>\r\n"
																		//+ $"<td align='left' style='width:10%;'>{(p.historyList[h].Salary.PayFreqType.code == "B" ? "Biweekly" : "Monthly")}</td>\r\n"
																		+ $"<td align='left' style='width:10%;'>{(p.historyList[h].Salary.PayFreqType?.code == "B" ? "Biweekly" : (p.historyList[h].Salary.PayFreqType?.code == null ? "&nbsp;" : "Monthly"))}</td>\r\n"

																		+ $"<td align='right' style='width:6%;'>{p.historyList[h].Salary.StandardHours.ToString()}</td>\r\n"
																		+ $"<td align='right' style='width:15%;'>{p.historyList[h].Salary.AnnualSalaryAmount}</td>\r\n"
																		+ $"<td align='right' style='width:14%;'>{p.historyList[h].Salary.dollarChange}&nbsp;-&nbsp;{p.historyList[h].Salary.percentChange.ToString()}%</td>\r\n"
																	+ $"</tr>\r\n"
																	+ $"<tr><td>&nbsp;</td></tr>\r\n"
																+ $"</table>\r\n";
								}
							}
							if (p.futureList.Length > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=100% style='border:0px solid black;font-size:12px; font:Tahoma;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='left' style='font-size:18px;font-weight:bold;' width=30%>Future</td></tr>\r\n</table>\r\n";

								sHtmlOut = sHtmlOut + $"<table width=100% style='border:1px solid black;font-size:12px; font:Tahoma;'>\r\n"
																+ $"<tr width='100%'>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Effective Date</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:15%;'><b>Compensation Change Reason</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Rate Type</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:10%;'><b>Amount</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:10%;'><b>Rate 2</b>&nbsp;</td>\r\n"
																	+ $"<td align='left' style='width:10%;'><b>Pay Frequency</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:6%;'><b>Standard Hours</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:15%;'><b>Annual Salary</b>&nbsp;</td>\r\n"
																	+ $"<td align='right' style='width:14%;'><b>Change</b>&nbsp;</td>\r\n"
																+ $"</tr>\r\n"
															+ $"</table>\r\n";

								for (int h = 0; h < p.futureList.Length; h++)
								{
									sHtmlOut = sHtmlOut + $"<table width=100% style='border:0px solid black;font-size:12px; font:Tahoma;'>\r\n"
																	+ $"<tr width='100%'>\r\n"
																		+ $"<td align='left' style='width:10%;'>{p.futureList[h].Salary.key.effDate}</td>\r\n"
																		+ $"<td align='left' style='width:15%;'>{p.futureList[h].Salary.IncreaseType.code}&nbsp;-&nbsp;{p.futureList[h].Salary.IncreaseType.description}</td>\r\n"
																		+ $"<td align='left' style='width:10%;'>{(p.futureList[h].Salary.RateType != null ? (p.futureList[h].Salary.RateType.code == "S" ? "Salary" : "Hourly") : "")}</td>\r\n"
																		+ $"<td align='right' style='width:10%;'>{p.futureList[h].Salary.Rate1Amount}&nbsp;-&nbsp;{p.futureList[h].Salary.Rate1CurrencyCode}</td>\r\n"
																		+ $"<td align='right' style='width:10%;'>{p.futureList[h].Salary.Rate2Amount}&nbsp;-&nbsp;{p.futureList[h].Salary.Rate2CurrencyCode}</td>\r\n"
																		//+ $"<td align='left' style='width:10%;'>{(p.futureList[h].Salary.PayFreqType.code == "B" ? "Biweekly" : "Monthly")}</td>\r\n"
																		+ $"<td align='left' style='width:10%;'>{(p.futureList[h].Salary.PayFreqType?.code == "B" ? "Biweekly" : (p.futureList[h].Salary.PayFreqType?.code == null ? "&nbsp;" : "Monthly"))}</td>\r\n"
																		+ $"<td align='right' style='width:6%;'>{p.futureList[h].Salary.StandardHours.ToString()}</td>\r\n"
																		+ $"<td align='right' style='width:15%;'>{p.futureList[h].Salary.AnnualSalaryAmount}</td>\r\n"
																		+ $"<td align='right' style='width:14%;'>{p.futureList[h].Salary.dollarChange}&nbsp;-&nbsp;{p.futureList[h].Salary.percentChange.ToString()}%</td>\r\n"
																	+ $"</tr>\r\n"
																	+ $"<tr><td>&nbsp;</td></tr>\r\n"
																+ $"</table>\r\n";
								}
							}
						}
						//sHtmlOut = sHtmlOut + $"</table>\r\n<br />";
						sHtmlOut = sHtmlOut + $"</body></html>";

						string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
						// Check if file exists, and rename if necessary
						int counter = 1;
						while (System.IO.File.Exists(fullPath))
						{
							newFileName = $"{baseFileName}_{counter}{extention}";
							fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
							counter++;
						}

						// Write the HTML content to the file
						System.IO.File.WriteAllText(fullPath, sHtmlOut);
						//System.IO.File.WriteAllText(System.IO.Path.Combine(outputDirectory, newFileName), sHtmlOut);
						Console.WriteLine("Wrote file: " + newFileName);
					}							
				}
			}
				catch (Exception ex)
			{
				// Handle exceptions gracefully
				Console.WriteLine($"An error occurred: {ex.Message}");
				// Additional error handling logic here			}
			}

		}

		static async Task getPositionHistoryHTML()
		{
			try
			{
				var sHtmlOut = "";

				var inputDirectory = @"F:\IT Company\GenericCompany\GC Pos Hist Summ Json";
				var outputDirectory = @"C:\Temp\Testing\GenericCompany\PosHistoryHtml";

				string[] files = Directory.GetFiles(inputDirectory);
				var cultureInfo = Thread.CurrentThread.CurrentCulture;
				var numberFormatInfo = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();

				foreach (string file in files)
				{
					PayRateHistADP p = new PayRateHistADP();

					string detailData = System.IO.File.ReadAllText(file);
					PositionHistorySummaryADP pos = new PositionHistorySummaryADP();
					try
					{
						pos = JsonConvert.DeserializeObject<PositionHistorySummaryADP>(detailData);
					}
					catch (Exception ex)
					{
						Console.WriteLine("Error: " + ex.Message);
					}

					string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file);
					Console.WriteLine(fileNameWithoutExtension);
					string fileName = System.IO.Path.GetFileName(file);

					string[] parts = fileNameWithoutExtension.Split('_');

					var paycom = parts[0];
					var aoid = parts[1];
					var coCode = parts[2];
					var lastName = parts[3];
					var firstName = parts[4];
					var lastFour = parts[5];
					var positionId = parts[6];
					//var empId = parts[7];
					//var empId = (parts.Length > 7 && !string.IsNullOrEmpty(parts[7])) ? parts[7] : "000000";
					var pfId = parts[8];

					bool found = false;
					EmployeeRecordADP matchedEmployee = null;
					foreach (var emp in Emp)
					{
						if (emp.positions != null && emp.positions[0].status.Length > 0)
						{
							if (positionId == emp.positions[0].positionId)
							{
								found = true;
								matchedEmployee = emp;
								break;
							}
						}
					}


					if (found && matchedEmployee != null)
					{
						var empId = "";
						if (matchedEmployee.positions[0].fileNumber != null)
							empId = matchedEmployee.positions[0].fileNumber;
						else
							empId = "000000";

						string baseFileName = $"{paycom}_{empId}_GC_{lastName}_{firstName}_{matchedEmployee.positions[0].positionId}_PositionHistory";
						string extention = ".html";
						var newFileName = baseFileName + extention;

						sHtmlOut = $"<html version=\"1.0\" encoding=\"UTF-8\"><font-size: 12px; font: Tahoma>"
						+ $"<!DOCTYPE html>\r\n<html>\r\n"
						+ $"<head>\r\n"
						+ $"<style>\r\n"
						+ $".grid2-container {{\r\n  display: grid;\r\n  grid-template-columns: auto auto;\r\n  background-color: #ffffff;\r\n}}\r\n"
						+ $".grid-itemL {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: left;\r\n}}\r\n"
						+ $".grid-itemR {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: right;\r\n}}\r\n"
						+ $".grid3-container {{\r\n  display: grid;\r\n  grid-template-columns: 35% 35% 30%;\r\n  background-color: #ffffff;\r\n}}\r\n"
						+ $".grid-itemL {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: left;\r\n}}\r\n"
						+ $".grid-itemC {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: center;\r\n}}\r\n"
						+ $".grid-itemR {{\r\n  border: 0px solid rgba(0, 0, 0, 0.8);\r\n  padding: 2px;\r\n  font-size: 14px;\r\n  text-align: right;\r\n}}\r\n"
						+ $"</style>\r\n"
						+ $"</head>\r\n"
						+ $"<body>\r\n";

						sHtmlOut = sHtmlOut + $"<table cellpadding=2 cellspacing=0 style='border:0px solid black; font-size:10px; font:Tahoma; width:100%;'>\r\n"
										+ $"<tr>\r\n<td align='center' style='font-size:18px;font-weight:bold;' width=100%>Position History Summary</td>\r\n</tr>\r\n"
										+ $"<tr>\r\n<td align='center' style='font-size:22px;' width=100%>{lastName}, {firstName}</td>\r\n</tr>\r\n"
										+ $"<tr>\r\n"
											+ $"<td align='center' style='font-size:10px;' width=100%>ADP ID: {aoid} &nbsp;&nbsp; Paycom ID: {paycom.Replace("0000", "n/a")} &nbsp;&nbsp; SSN Last 4: {lastFour} &nbsp;&nbsp; Employee Pos ID: {positionId}</td>\r\n"
										+ $"</tr>\r\n"
										+ $"<tr>\r\n<td align='center' style='font-size:10px;' width=100%>{DateTime.Now}</td>\r\n</tr>\r\n"
										+ $"<tr>\r\n"
											+ $"<td width=100%>\r\n"
												+ $"<table style='border:1px solid black;font-size:10px;' cellpadding=2 cellspacing=0>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;EIN&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].coCode}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Job Title&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].jobTitle}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Position ID&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].positionId}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n<td style='text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Department&nbsp;</td>\r\n<td style='border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].homeDepartment}&nbsp;</td>\r\n</tr>\r\n"
													+ $"<tr>\r\n"
														+ $"<td style='border-top:1px solid black;text-align:right;background-color:#CCCCCC;width:150px;'>&nbsp;Status&nbsp;</td>\r\n"
														+ $"<td style='border-top:1px solid black;border-left:1px solid black'>&nbsp;{matchedEmployee.positions[0].status}&nbsp;</td>\r\n"
													+ $"</tr>\r\n"
												+ $"</table>\r\n"
											+ $"</td>\r\n"
										+ $"</tr>\r\n"
									+ $"</table>\r\n";
						if (pos.currentList.Length + pos.historyList.Length + pos.futureList.Length == 0)
						{
							sHtmlOut = sHtmlOut + $"<table width=98% style='border:0px solid black;font-size:12px;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='center' style='font-size:22px;font-weight:bold;' width=100%>Employee has no Position History</td></tr>\r\n</table>\r\n";
						}
						else
						{
							if (pos.currentList.Length > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=98% style='border:0px solid black;font-size:12px;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='left' style='font-size:18px;font-weight:bold;' width=30%>Current</td></tr>\r\n</table>\r\n";

								sHtmlOut = sHtmlOut + $"<table width=98% style='border:1px solid black;font-size:12px;'>\r\n"
															+ $"<tr width='100%'>\r\n"
															+ $"<td align='center' width='10%'><b>Effective Date</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Job Title/Status</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Home Department</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Home Cost Number</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Worked in Country</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Location</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Benefits Eligibility Class</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Pay Grade</b>&nbsp;</td>\r\n"
															+ $"</tr>\r\n"
															+ $"</table>\r\n";

								sHtmlOut = sHtmlOut + $"<table width=98% style='border:0px solid black;font-size:14px;'>\r\n"
															+ $"<tr width='100%'>\r\n"
															+ $"<td valign='top' align='center' width='10%'>{pos.currentList[0].effDate}</td>\r\n"
															+ $"<td valign='top' align='center' width='15%'>{pos.currentList[0].jobTitleDesc}/{pos.currentList[0].statusDesc}</td>\r\n"
															+ $"<td valign='top' align='center' width='15%'>{pos.currentList[0].homeDeptDesc}</td>\r\n"
															+ $"<td valign='top' align='center' width='10%'>{pos.currentList[0].homeCostDesc}</td>\r\n"
															+ $"<td valign='top' align='center' width='10%'>{pos.currentList[0].workedInCountry}</td>\r\n"
															+ $"<td valign='top' align='center' width='10%'>{pos.currentList[0].locationDesc}</td>\r\n"
															+ $"<td valign='top' align='center' width='15%'>{pos.currentList[0].benefitEligibiityDesc}</td>\r\n"
															+ $"<td valign='top' align='center' width='10%'>{pos.currentList[0].payGradeDesc}</td>\r\n"
															+ $"</tr>\r\n"
															+ $"</table>\r\n";
							}
							if (pos.historyList.Length > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=98% style='border:0px solid black;font-size:12px;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='left' style='font-size:18px;font-weight:bold;' width=30%>History</td></tr>\r\n</table>\r\n";

								sHtmlOut = sHtmlOut + $"<table width=98% style='border:1px solid black;font-size:12px;'>\r\n"
															+ $"<tr width='100%'>\r\n"
															+ $"<td align='center' width='10%'><b>Effective Date</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Job Title/Status</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Home Department</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Home Cost Number</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Worked in Country</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Location</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Benefits Eligibility Class</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Pay Grade</b>&nbsp;</td>\r\n"
															+ $"</tr>\r\n"
															+ $"</table>\r\n";

								for (int h = 0; h < pos.historyList.Length; h++)
								{
									sHtmlOut = sHtmlOut + $"<table width=98% style='border:0px solid black;font-size:14px;'>\r\n"
																+ $"<tr width='100%'>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.historyList[h].effDate}</td>\r\n"
																+ $"<td valign='top' align='center' width='15%'>{pos.historyList[h].jobTitleDesc}/{pos.historyList[h].statusDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='15%'>{pos.historyList[h].homeDeptDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.historyList[h].homeCostDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.historyList[h].workedInCountry}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.historyList[h].locationDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='15%'>{pos.historyList[h].benefitEligibiityDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.historyList[h].payGradeDesc}</td>\r\n"
																+ $"</tr>\r\n"
																+ $"<tr><td>&nbsp;</td></tr>\r\n"
																+ $"</table>\r\n";
								}
							}
							if (pos.futureList.Length > 0)
							{
								sHtmlOut = sHtmlOut + $"<table width=98% style='border:0px solid black;font-size:12px;'>\r\n<tr><td>&nbsp;</td></tr>\r\n<tr><td align='left' style='font-size:18px;font-weight:bold;' width=30%>Future</td></tr>\r\n</table>\r\n";

								sHtmlOut = sHtmlOut + $"<table width=98% style='border:1px solid black;font-size:12px;'>\r\n"
															+ $"<tr width='100%'>\r\n"
															+ $"<td align='center' width='10%'><b>Effective Date</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Job Title/Status</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Home Department</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Home Cost Number</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Worked in Country</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Location</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='15%'><b>Benefits Eligibility Class</b>&nbsp;</td>\r\n"
															+ $"<td align='center' width='10%'><b>Pay Grade</b>&nbsp;</td>\r\n"
															+ $"</tr>\r\n"
															+ $"</table>\r\n";

								for (int h = 0; h < pos.futureList.Length; h++)
								{
									sHtmlOut = sHtmlOut + $"<table width=98% style='border:0px solid black;font-size:14px;'>\r\n"
																+ $"<tr width='100%'>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.futureList[h].effDate}</td>\r\n"
																+ $"<td valign='top' align='center' width='15%'>{pos.futureList[h].jobTitleDesc}/{pos.futureList[h].statusDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='15%'>{pos.futureList[h].homeDeptDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.futureList[h].homeCostDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.futureList[h].workedInCountry}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.futureList[h].locationDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='15%'>{pos.futureList[h].benefitEligibiityDesc}</td>\r\n"
																+ $"<td valign='top' align='center' width='10%'>{pos.futureList[h].payGradeDesc}</td>\r\n"
																+ $"</tr>\r\n"
																+ $"<tr><td>&nbsp;</td></tr>\r\n"
																+ $"</table>\r\n";
								}
							}
							//sHtmlOut = sHtmlOut + $"</table>\r\n<br />";
						}
						sHtmlOut = sHtmlOut + $"</body></html>";

						string fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
						// Check if file exists, and rename if necessary
						int counter = 1;
						while (System.IO.File.Exists(fullPath))
						{
							newFileName = $"{baseFileName}_{counter}{extention}";
							fullPath = System.IO.Path.Combine(outputDirectory, newFileName);
							counter++;
						}

						// Write the HTML content to the file
						System.IO.File.WriteAllText(fullPath, sHtmlOut);

						//System.IO.File.WriteAllText(System.IO.Path.Combine(outputDirectory, newFileName), sHtmlOut);
						Console.WriteLine("Wrote new html file: " + newFileName);
					}
				}
			}
			catch (Exception ex)
			{
				// Handle exceptions gracefully
				Console.WriteLine($"An error occurred: {ex.Message}");
				// Additional error handling logic here			}
			}
		}

		static async void LoadEmps()
				{
					var json = System.IO.File.ReadAllText("C:\\Temp\\Testing\\GenericCompany\\emps.json");
					Emp = JsonConvert.DeserializeObject<List<EmployeeRecordADP>>(json);
					Console.WriteLine("Number of Employees Loaded: " + Emp.Count);

			var crosswalkjson = System.IO.File.ReadAllText("C:\\Temp\\Testing\\GenericCompany\\mincrosswalk.json");
			CrosswalkEmps = System.Text.Json.JsonSerializer.Deserialize<List<CrosswalkEmp>>(crosswalkjson);

			//var crosswalkjson = System.IO.File.ReadAllText("C:\\Temp\\Testing\\GenericCompany\\Crosswalk.json");
			//FullCrossWalkEmps = System.Text.Json.JsonSerializer.Deserialize<List<CrosswalkRoot>>(crosswalkjson);

		}
		static async void LoadPosEmps()
		{
			var json = System.IO.File.ReadAllText("C:\\Temp\\Testing\\GenericCompany\\ADP GC empsX Pos View.json");
			Emp = JsonConvert.DeserializeObject<List<EmployeeRecordADP>>(json);
			Console.WriteLine("Number of Employees Loaded: " + Emp.Count);

			var crosswalkjson = System.IO.File.ReadAllText("C:\\Temp\\Testing\\GenericCompany\\mincrosswalk.json");
			CrosswalkEmps = System.Text.Json.JsonSerializer.Deserialize<List<CrosswalkEmp>>(crosswalkjson);
		}

				static async Task<bool> GetBrowser()
				{
					try
					{
						browser = await Puppeteer.ConnectAsync(new ConnectOptions()
						{
							BrowserURL = $"http://localhost:{browserPort}",
							DefaultViewport = null  //new ViewPortOptions() { Width = 1800, Height = 5000, DeviceScaleFactor = 1 }
						});

						Console.WriteLine("Browser connected");

						return false;
					}
					catch (Exception ex)
					{
						Console.WriteLine("ERROR No Localhost - " + ex.Message);

						var fetcher = new BrowserFetcher();

						//await fetcher.DownloadAsync("1002410");
						//var executablePath = fetcher.GetExecutablePath("1002410");

						await fetcher.DownloadAsync(PuppeteerSharp.BrowserFetcher.DefaultChromiumRevision);
						var executablePath = fetcher.GetExecutablePath(BrowserFetcher.DefaultChromiumRevision);

						browser = await Puppeteer.LaunchAsync(new LaunchOptions
						{
							Headless = false, //runHeadless,
							DefaultViewport = null, //new ViewPortOptions() { Width = 1800, Height = 5000, DeviceScaleFactor = 1 },
							ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
							//ExecutablePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe",
							UserDataDir = System.IO.Path.Combine(baseDir, browserProfileName),
							Args = new string[] { $"--remote-debugging-port={browserPort}", "--print-to-pdf-no-header", "--kiosk-printing", "--disable-web-security", "--disable-features=IsolateOrigins,site-per-process" }
							//Args = new string[] { "--remote-debugging-port=54322", "--print-to-pdf", "--print-to-pdf-no-header" }
						});


						//browser = await Puppeteer.LaunchAsync(new LaunchOptions
						//{
						//    Headless = false, //runHeadless,
						//    DefaultViewport = null, //new ViewPortOptions() { Width = 1800, Height = 5000, DeviceScaleFactor = 1 },
						//    ExecutablePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe",
						//    UserDataDir = Path.Combine(baseDir, browserProfileName),
						//    Args = new string[] { $"--remote-debugging-port={browserPort}", "--print-to-pdf-no-header", "--kiosk-printing", "--disable-web-security", "--disable-features=IsolateOrigins,site-per-process" }
						//    //Args = new string[] { "--remote-debugging-port=54322", "--print-to-pdf", "--print-to-pdf-no-header" }
						//});

						Console.WriteLine("Browser launched");

						return true;
					}
				}

				static async Task Login()
				{
					var page = (await browser.PagesAsync()).First();

					//page.Dialog += async (obj, args) => { await args.Dialog.Accept(); };

					await page.GoToAsync(loginUrl, new NavigationOptions() { WaitUntil = new[] { WaitUntilNavigation.Networkidle0 } });

					await page.WaitForTimeoutAsync(2000);

					//await page.EvaluateExpressionAsync("$('#txtCompanyName').val('')");
					//await page.TypeAsync("#CompanyId", companyLogin);
					await page.TypeAsync("[label='login-username']", userName);
					//await page.ClickAsync("#verifUseridBtn");
					await page.WaitForTimeoutAsync(2000);
					await page.TypeAsync("#username-text-field", password);
					await page.WaitForTimeoutAsync(1000);
					await page.ClickAsync("#login-button");

					await Task.Delay(3000);
				}
			}
		}
	


