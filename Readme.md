# Introduction

This repo contains the code for automating the Zoho Corporation Presentation Slide Show site in Chrome Driver.


# Getting Started
 
1.  Installation process 

    a. Install JDK latest version.
	b. Install Eclipse latest version.
	c. Install Selenium Server Standalone Package.
	d. Steps to update Environment Variable on the Project (Since we used Chrome explorer to automate the site, we need to provide the actual physical path of Chrome.exe from the machine)
		i. Open Properties window by right click on the Project.
		ii. Go to Run/Debug Settngs.
		iii. Edit the Project on the list shown.
		iv. On the Environment tab, please replace value for ChromeDriverExePath key to the actual physical path of Chrome.exe file.
 

2.  Software dependencies

    N/A

# Build and Test

In Eclipse, right-click the Project and hit Build Path. On the Build Path prompt, go to Libraries tab. On the ClassPath please include the downloaded Selenium Server Standalone jar file as Add External JARs.
 
Right-click on the application and click 'Run as -- Java Application' to run the automation.