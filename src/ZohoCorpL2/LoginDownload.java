package ZohoCorpL2;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.interactions.Actions;


public class LoginDownload {
	ChromeDriver driver;

	String url = System.getenv("TestSiteEndPoint");
	
	public void waitfor(int time)
	{
		int a=time*20000;
		int b = 0;
		for(int i=0;i<a;i++)
		{
			for(int j=0;j<a;j++)
			{
				b++;
			}
		}
	}
	
	public void invokeBrowser()
	{
		System.setProperty("webdriver.chrome.driver", System.getenv("ChromeDriverExePath"));
		driver = new ChromeDriver();
		driver.manage().window().maximize();
		driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
		driver.get(url);
		}
		

	public void closeBrowser()
	{
		driver.close();
	}
	
	public void login(String Username) {
		WebElement linkText = driver.findElement(By.linkText("LOGIN"));
		linkText.click();
        WebElement usernameElement = driver.findElement(By.name("LOGIN_ID"));
		usernameElement.sendKeys(Username);

		driver.findElement(By.id("nextbtn")).click();
		LoginDownload ld=new LoginDownload();
	ld.waitfor(180);
		
		
	}
	public void gridlist()
	{
		driver.findElement(By.xpath("//button[@data-title='List View']")).click();
		driver.findElement(By.xpath("//button[@data-title='Grid View']")).click();
	
	}
	
	public void download()
	{
		Actions action = new Actions(driver);
		WebElement we= driver.findElement(By.xpath("(//div[@id='zs_imgCont'])[1]"));
		action.moveToElement(we).build().perform();
		driver.findElement(By.xpath("(//button[@id=\"zs_download\"])[1]")).click();
	}
	
	
public void customslide()
{
	driver.findElement(By.xpath("(//div[@id='zs_imgCont'])[1]")).click();
	for(String winHandle : driver.getWindowHandles()){
	    driver.switchTo().window(winHandle);
	}
	driver.findElement(By.xpath("//button[@popup='slideshowsetupmenu']")).click();
	driver.findElement(By.xpath("(//span[text()='Custom Slideshow']//parent::li)[2]")).click();	
	boolean result1= driver.findElement(By.xpath("//h3[text()='Create Custom Slideshow']")).isDisplayed();
	assert result1;
	driver.findElement(By.xpath("(//span[@class='ui-right ui-customshow-close'])[1]")).click();
}

public void commentresolve()
{
	Actions action = new Actions(driver);
	action.contextClick(driver.findElement(By.xpath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']"))).perform();
	driver.findElement(By.xpath("//span[text()='Add Comment']")).click();	
	driver.findElement(By.xpath("//div[@id='comments_text']")).click();
	action.sendKeys("H");
	driver.findElement(By.xpath("//div[@class='postcomment']")).click();
	driver.findElement(By.xpath("//span[text()='Resolve']//parent::button")).click();
}

public void sliderightclick()
{
	Actions action = new Actions(driver);
	action.contextClick(driver.findElement(By.xpath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']"))).perform();
	driver.findElement(By.xpath("//span[text()='Hide/Show Slide']")).click();
	boolean result1= driver.findElement(By.xpath("//div[@class='ui-zthumbnail ui-zthumbnail-selected ui-zthumbnail-hidden']")).isDisplayed();
	assert result1;
	action.contextClick(driver.findElement(By.xpath("//div[@class='ui-zthumbnail ui-zthumbnail-selected ui-zthumbnail-hidden']"))).perform();
	driver.findElement(By.xpath("//span[text()='Hide/Show Slide']")).click();
	boolean result2= driver.findElement(By.xpath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']")).isDisplayed();
	assert result2;
	action.contextClick(driver.findElement(By.xpath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']"))).perform();
	driver.findElement(By.xpath("//span[text()='Add Comment']")).click();
	boolean result3= driver.findElement(By.xpath("//div[@class='commentbox']")).isDisplayed();
	assert result3;
	
}
public void fileoptions()
{
	driver.findElement(By.xpath("//a[@id='fileMenu']")).click();
	driver.findElement(By.xpath("//span[text()='Make a Copy']")).click();
	driver.findElement(By.xpath("//span[@class='ui-button-text'][text()='Make a Copy']")).click();
	boolean result1= driver.findElement(By.xpath("//div[text()='Copy of Different types of mouse']")).isDisplayed();
	assert result1;
	
	driver.findElement(By.xpath("//a[@id='fileMenu']")).click();
	driver.findElement(By.xpath("//span[text()='Open...']")).click();
	boolean result2= driver.findElement(By.xpath("//span[text()='Open File']")).isDisplayed();
	assert result2;
	
	
	}

	public static void main(String[] args) {
		 try {
		LoginDownload ld=new LoginDownload();
		ld.invokeBrowser();
		ld.login("cathrynnikitha4@gmail.com");
		ld.customslide();
		ld.commentresolve();
		ld.sliderightclick();
		ld.fileoptions();
		ld.closeBrowser();
		} catch (Exception ex) { }
	}
}


