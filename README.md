# CryptoViewer
First of all i create architecture for project and make key directory for him. (Services, Model, View and Navigation). This is to maintain a clean code approach and to make it easier for you to navigate the project. It is also convenient for further development if several people are working on the project.

Next step. I started write code and for start i work with Services. Write Interface and base service class. Then, i start work with Models. For all property i give JsonProperty for work in future.

Configuring MainWindow and testing whether the server works on the page frame in plain text through functionality.

Added a page with a search bar and a list of cryptocurrencies. Also at the bottom of the page you can see a small post with details about the coin. At this stage, the problems with pulling data via the API were due to the format of use and its integration into the code.

Added a function for a detailed coin page via double-click. Also conditionally added a function for displaying the top 10 coins, where I initially specified to display 20 but decided to make a separate method with a specific name to highlight it.In general, the program works, but when you select a coin and double-click, the window freezes, probably data is being transferred from the API to the local program and the program waits, but for a long time, these are my suspicions)).

Added themes for main page.
