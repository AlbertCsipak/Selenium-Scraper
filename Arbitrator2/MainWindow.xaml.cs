using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Arbitrator2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		IWebDriver driver1;
		IWebDriver driver2;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var options = new ChromeOptions();
			options.AddArgument("--ignore-certificate-errors");
			options.AddArgument("--start-maximized");
			//options.AddArgument("--headless"); //hide browser

			//options.AddArgument(@"user-data-dir=C:\Users\Albi\AppData\Local\Google\Chrome\User Data");

			driver1 = new ChromeDriver(options);

			driver1.Navigate().GoToUrl("https://hu1.unibet.com/betting/sports/filter/all/all/all/all/in-play");

			int fetchRate = 100;
			bool foundElement = false;

			foundElement = false;
			while (!foundElement)
			{
				try
				{
					By cookieButton = By.XPath("//*[@id=\"CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll\"]");
					driver1.FindElement(cookieButton).Click();
					foundElement = true;
				}
				catch (Exception)
				{
					foundElement = false;
				}
				System.Threading.Thread.Sleep(fetchRate);

			}

			for (int i = 0; i < 20; i++)
			{
				try
				{
					By collapsedButton = By.ClassName("eEdLwE");
					driver1.FindElement(collapsedButton).Click();
				}
				catch (Exception)
				{
					;
				}
				System.Threading.Thread.Sleep(fetchRate);

			}

			for (int i = 0; i < 60; i++)
			{
				try
				{
					By collapsedButton = By.ClassName("hDaRiN");
					driver1.FindElement(collapsedButton).Click();
				}
				catch (Exception)
				{
					;
				}
				System.Threading.Thread.Sleep(fetchRate);

			}




			Task fetchData = new Task(t =>
			{
				List<Match> matches = new List<Match>();
				int nameCounter = 0;


				Match match = new Match();
				try
				{
					By nameHome = By.ClassName("KambiBC-event-participants__name");
					match.NameHome = driver1.FindElements(nameHome)[nameCounter].Text;
					nameCounter++;
					By nameAway = By.ClassName("KambiBC-event-participants__name");
					match.NameAway = driver1.FindElements(nameAway)[nameCounter].Text;
					nameCounter++;

					Odds odds = new Odds();
					By oddsHomeName = By.ClassName("iSxyet");
					if (driver1.FindElements(oddsHomeName)[0].Text==match.NameHome)
					{
						odds.BookmakerName = "Unibet";
						By oddsHomeValue = By.ClassName("iYOCD");
						odds.OddsHome = int.Parse(driver1.FindElements(oddsHomeValue)[0].Text);

					}
					
					
					
					
					match.Odds.Add(odds);
					matches.Add(match);

				}
				catch (Exception)
				{

				}

				

				System.Threading.Thread.Sleep(fetchRate);

			}, TaskCreationOptions.LongRunning);

			fetchData.Start();
			
			while (true)
			{
				System.Threading.Thread.Sleep(fetchRate);
			}
		}
    }
}
