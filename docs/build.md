# Build


Context: Section 4.e.i.D of 

    https://eng.ms/docs/initiatives/executive-order/executive-order-requirements/executiveorderoncybersecurity/buildinfraops#build-system-security-requirements

*   Context: 

    https://microsoft.sharepoint.com/❌/r/teams/1ES2/_layouts/15/doc2.aspx?sourcedoc=%7B97E1B064-A768-4B0F-BEB5-4BF21577F3D6%7D&file=9d770e15-6208-4284-b347-b2762803623b.xlsx


Adds support to xaprepare to generate a buildtoolsinventory.csv file
which contains information about various build tools we depend on.

Items currently included are 

*   dotnet, 

*   Android SDK and NDK packages,

*   Open JDK, 

*   Mono MDK, 

*   various tools (`brew`)

