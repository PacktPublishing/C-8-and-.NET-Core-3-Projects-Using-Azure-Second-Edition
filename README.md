## $5 Tech Unlocked 2021!
[Buy and download this Book for only $5 on PacktPub.com](https://www.packtpub.com/product/c-8-and-net-core-3-projects-using-azure-second-edition/9781789612080)
-----
*If you have read this book, please leave a review on [Amazon.com](https://www.amazon.com/gp/product/178961208X).     Potential readers can then use your unbiased opinion to help them make purchase decisions. Thank you. The $5 campaign         runs from __December 15th 2020__ to __January 13th 2021.__*

# C# 8 and .NET Core 3 Projects Using Azure - Second Edition 

<a href="https://www.packtpub.com/in/web-development/c-8-and-net-core-3-0-projects-second-edition?utm_source=github&utm_medium=repository&utm_campaign=9781789612080"><img src="https://www.packtpub.com/media/catalog/product/cache/e4d64343b1bc593f1c5348fe05efa4a6/9/7/9781789612080-original.jpeg" alt="C# 8 and .NET Core 3 Projects Using Azure - Second Edition " height="256px" align="right"></a>

This is the code repository for [C# 8 and .NET Core 3 Projects Using Azure - Second Edition ](https://www.packtpub.com/in/web-development/c-8-and-net-core-3-0-projects-second-edition?utm_source=github&utm_medium=repository&utm_campaign=9781789612080), published by Packt.

**Build professional desktop, mobile, and web applications that meet modern software requirements**

## What is this book about?
.NET Core is a general-purpose, modular, cross-platform, and opensource implementation of .NET. The latest release of .NET Core 3 comes with improved performance and security features, along with support for desktop applications. .NET Core 3 is not only useful for new developers looking to start learning the framework, but also for legacy developers interested in migrating their apps. Updated with the latest features and enhancements, this updated second edition is a step-by-step, project-based guide.


This book covers the following exciting features:
* Understand how to incorporate the Entity Framework Core 3 to build ASP.NET Core MVC applications 
* Create a real-time chat application using Azure’s SignalR service 
* Gain hands-on experience of working with Cosmos DB 
* Develop an Azure Function and interface it with an Azure Logic App 
* Explore user authentication with Identity Server and OAuth2 
* Understand how to use Azure Cognitive Services to add advanced functionalities with minimal code 
* Get to grips with running a .NET Core application with Kubernetes

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/178961208X) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>

## Errata
* Page 139, 140: Step 2 contains the following code:
```
connection.on('UpdateChat', (user, message) => {
  updateChat(user, message);
});
connection.on('Archived', (message) => {
  updateChat('system', message);
});
```
On page 140, step 6 the book defines an "updateChatPanel" method. Either the code on page 139 needs to be changed to
reference "updateChatPanel" instead of "updateChat" or the function for page 140, step 6 needs to be "updateChat".
* Page 141: The last line of the archiveChat function on the top of the page is missing a parameter between 'ArchiveChat' and archivePath. The parameter 'archivedBy' needs to be added in order for archiving chat to work.

## Instructions and Navigations
All of the code is organized into folders. For example, Chapter02.

The code will look like the following:
```
public class Document
{
public string Title { get; set; }
public string FileName { get; set; }
public string Extension { get; set; }
public DateTime LastAccessed { get; set; }
public DateTime Created { get; set; }
public string FilePath { get; set; }
public string FileSize { get; set; }
}
```

**Following is what you need for this book:**
This book is for developers and programmers of all levels who want to build real-world projects and explore the new features of .NET Core 3. Developers working on legacy desktop software who are looking to migrate to .NET Core 3 will also find this book useful. Basic knowledge of .NET Core and C# is assumed.

With the following software and hardware list you can run all code files present in the book (Chapter 1-10).
### Software and Hardware List
| Chapter | Software required | OS required |
| -------- | ------------------------------------ | ----------------------------------- |
| 1-10 | Visual Studio 2019 | Windows, Mac OS X, and Linux (Any) |

We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://static.packt-cdn.com/downloads/9781789612080_ColorImages.pdf).

### Related products
* Hands-On Software Architecture with C# 8 and .NET Core 3  [[Packt]](https://www.packtpub.com/in/programming/hands-on-software-architecture-with-c-8?utm_source=github&utm_medium=repository&utm_campaign=9781789800937) [[Amazon]](https://www.amazon.com/dp/1789800935)

* Hands-On RESTful Web Services with ASP.NET Core 3  [[Packt]](https://www.packtpub.com/in/application-development/hands-restful-web-services-aspnet-core?utm_source=github&utm_medium=repository&utm_campaign=9781789537611) [[Amazon]](https://www.amazon.com/dp/1789537614)

## Get to Know the Author
**Paul Michaels**
is a Lead Developer with over 20 years experience. He likes programming, playing with new technology and solving problems. When he’s not working, you can find him cycling or walking around The Peak District, playing table tennis, or trying to cook for his wife and two children. You can follow him on twitter at @paul_michaels, or find him on LinkedIn by searching for pcmichaels. He also writes a blog for which the link is available on both his LinkedIn and Twitter profiles.

**Dirk Strauss**
is a full-stack developer with Embrace. He enjoys learning and sharing what he learns with others. Dirk has published books on C# for Packt as well as ebooks for Syncfusion. In his spare time, he relaxes by playing guitar and trying to learn Jimi Hendrix licks. You can find him at @DirkStrauss on Twitter.

**Jas Rademeyer**
has been a part of the IT industry for over 15 years, focusing on the software side of things for most of his career.With a degree in information science, specializing in multimedia, he has been involved in all facets of development, ranging from architecture and solution design to user experience and training. He is currently plying his trade as a technical solutions manager, where he manages development teams on various projects in the Microsoft space. A family man and a musician at heart, he spends his free time with his wife and two kids and serves in the worship band at church.

### Suggestions and Feedback
[Click here](https://docs.google.com/forms/d/e/1FAIpQLSdy7dATC6QmEL81FIUuymZ0Wy9vH1jHkvpY57OiMeKGqib_Ow/viewform) if you have any feedback or suggestions.
