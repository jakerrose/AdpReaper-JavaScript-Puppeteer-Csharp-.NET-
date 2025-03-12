# ADP Reaper
*I will explain this solution which was used for web scraping, calling API fetches, and more in the ADP system*

This is a solution that was used as part of my job as Software Developer for an Oregon based IT startup company. We assisted the client in data migration from their old system in ADP to their new Paycom system.
I was tasked with collected documents and data of all employees, past and present, including training materials, I9 forms, W2's, 1095-C's, benefit enrollment history, pay history, and position history. 

This solution runs in Visual Studio 2022 in a .NET framework (8.0). The main programming language is C# and uses JavaScript and the JavaScript library PuppeteerSharp. When the application is run, the Run() function 
is called which calls the app.config settings and launches the Puppeteer browser and all its settings. From the task GetBrowser you can change the browser and helpful settings like kiosk-printing which controls what 
happens when the print button is clicked in the browser. Using the app.config settings, the browser launches the specified starting url and types in the username and password and clicks the login button with Puppeteer. 
In the first try catch are the Tasks that one can select to run. If one is uncommented, it will just run that one, or else it will loop back around once the task is complete and start the next.

## employeeFetch()
The purpose of this task is go create a JSON file of a list of all employees in the company. This information is found as a network XHR fetch in the browsers' API upon loading of a certain page. By copying the fetch, I created this  JavaScript fetch call. This will save a file with all employee information that the system uses including name, multiple id numbers, status, hire date, and much more. There is associate view which just has information about an employee's current position and position view which has all historical positions. Whenever this data is needed for the rest of the solution, it can be called and loaded into the class EmployeeSearchResponse.cs. I use this JavaScript fetch call in a C# string that is requested to the HTTP of the browser through Puppeteer. This is a POST request with filters such as number of results, sorting prefernces, etc. The response is a JSON payload that is converted with C# into a JSON list file. The static async void LoadEmps() can be called before the next task to deserialize the JSON into the list EmployeeRecordADP so that the data is already ready to use to loop through employees, define variables, and more.
		
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

## GetLMSPdf()
This collection is to get training documents for employees from a very old LMS system that did not use any API fetches. I had to rely on scraping the DOM to get the data I was after and to collect the needed  documents. The system was designed as a series of folders, some containing links to download documents, others just more folders. I used this JavaScript to evaluation the HTML and find the links I was after. If one was found, it would be stored in a JSON file:

    var script = @"
            Array.from(document.querySelectorAll('a[href^=""/lms/servlet/lms/FRFILE?RID""]'))
                .map(a => a.outerHTML)";
                
    var elements = await page.EvaluateExpressionAsync<string[]>(script);


If no links to documents were found, the link to the next layer of folders would be saved. Since there was up to four layers of folders in these structures, I repeated my loop four times to save JSON files of download
and folder links four layers deep. After that, I could look for files. This C# code uses Puppeteer to evaluate JavaScript code in a web page context and extract information from certain elements. I store the filenames 
and links into pairs to use later:

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

    
For each pair, I could now use the pathValue to define the URL of the file and download with this code. Here I use JavaScript to fetch the file from the url, then convert the http response into a blob.
The onloadend event fires when the reading is complete, and it resolves the promise with the Base64 string:

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

The scraped data is used to name the pdf file and save to the chosen output folder.

## getEnrollmentHistory()
This method is a simple example of a process automation script using Puppeteer. The variable page is established as the Puppeteer controlled browser page and downloadPath is established as the default path for
the pdf that is downloaded. In this system, the pdf always has the same name when downloaded. The GoToAsync() function is used to browse to a url. We define the button we want to click on to view the appropriate page by using QuerySelectorAsync() on the css selector. A timeout is called to give Puppeteer more time to locate the selector. ClickAsync() is used to simulate clicking on the selector.

We have already loaded the employee JSON file into our class and can loop through each. We have collected the employee JSON from a fetch in the same system we're working in so they are listed in the same order as in the UI. That way, we can end our loop by simulating clicking to the next employee in the UI and they will match up. When the loop begins, we set up the naming of the file using the employee name and old file number from our list as well as a separate JSON list called the crosswalk which contains the employee's new ID number. If the old number matches the new number, that employee is also assigned a new ID, or else "0000":
		
		CrosswalkEmp paycomPerson = CrosswalkEmps.FirstOrDefault(person => person.ClockSeq == emp.positions[0].fileNumber);
		var paycomId = "";
		if (paycomPerson != null)
				paycomId = paycomPerson.Employee_Code;
		else
				paycomId = "0000";
A variable for the print button is established, then clicked, causing a pdf to be downloaded into our downloadPath. There is then a check to see if that file exists in the downloadPath. If it does, it is renamed to 
our convention and moved to another folder. A click to the next page and our loop restarts.

## getI9emps() and getI9info()

This collection worked with a different part of the ADP website that was also less than modern technology. My task was to go to the I9 section of the site, select each employee's page, then get screenshots of multiple tabs. My first step was to get a network fetch from that specific page to create a new JSON file of those employees listed. This was needed in order to identify each employee in order to name correctly, which I'll get to. 

There were four categories of employees, active and closed and I simply wrote a loop for eaach and established the number of employees for each and commented out the others (this repo only shows two). I went to the correct tab manually, established a GoToAsync() at the beginning of the loop to refresh the page, and set up the viewport for screenshots. Each tab was a long list of employee names. I set up the nameLink selector which uses css and the index of the loop to click on the current employee: 

		var nameLink = await page.QuerySelectorAsync($"#EI9_DASHBOARD_GRID_{i} > div > div > div > div.vdl-col-xs.ei9-grid-cell.mdf-d-table > a");

Before an employee link is clicked, I must create an event listener that will fetch certain data from the network. I target the url to listen for on a click event. If that url is detected, it will load the network response in JSON form into my class I9Root which is derived from my getI9emps() function. The employee's information is deserialized and loaded and then the value for social security number is looped and compared with ssn's from my regular employee list. When a match is found, I can then identify the employee we are working with and complete the naming conventions. Event listener code:

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

  The ClickAsync() on nameLink triggers the listener. If nameLink can't be found in the if else statement, a page down action in Puppeteer is triggered to scroll farther down the page. On the employee's page, each tab is screenshotted and given a descriptive name.

## PayHistoryHtml()

While the goal is usually to collect original documents, sometimes it is necessary to recreate documents from data within the JSON files. This is usually if it is much quicker to download the smaller JSON files instead of downloading PDFs or doing screenshots and will help us meet a deadline. In the case of this solution, another developer collected the JSON files with data about employees' pay history. This C# code constructs an HTML string using embedded CSS styles for layout grids.

The JSON files are named such that some of the information we need is already in the filename. We can split the filename by parts at the underscore into an array and construct variables for each part. Our top loop uses each JSON file and a nested foreach loop matches the position id from the filename with the positionId variable in our employee class to match the correct employee. Once we have loaded the employee's data into our employee class, we can pull data from the employee class as well as the PayRateHistoryADP class, which contains information about the employee's salary. 

The HTML and CSS is written to match the style of the downloaded document. This template works for each JSON file in the loop and extracts employee and salary information from the classes and loads into the HTML string. At the end of the loop, the HTML string is written to an HTML file and named using System.IO.WriteAllText()

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
