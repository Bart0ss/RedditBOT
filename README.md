# RedditBOT
Scanning Reddit comments with C# + RedditSharp 

# What is this BOT about?

At this moment it is scanning given amount of threads of given subreddit
  e.g 50 threads from http://reddit.com/r/news
  and does stuff that you'll tell him to do

# What kind of 'stuff' can it do?
At this moment there's only checking if comment (not post) author has birthday today (his reddit account of course)
and if he does, then bot is replying to him with an ASCII ART from bin/Debug/cake.txt and inserts his name into it

Happy Cakeday!

    *HHH   HHH*    *AA*    *PPPPP*   *PPPPP*   *YYY     YYY*
    *HHH   HHH*  *AA  AA*  *PP  PP*  *PP  PP*   *YYY   YYY*
    *HHH   HHH*  *AA  AA*  *PP  PP*  *PP  PP*    *YYY YYY*
    *HHHHHHHHH*  *AAAAAA*  *PPPPP*   *PPPPP*      *YYYYY*
    *HHH   HHH*  *AA  AA*  *PP*      *PP*          *YYY*
    *HHH   HHH*  *AA  AA*  *PP*      *PP*          *YYY*
    *HHH   HHH*  *AA  AA*  *PP*      *PP*          *YYY*

                         Username!                       

    *BBBBB            *DDDDD          *AAAA    *YYY     YYY
    *BB  BBB          *DD  DDD       *AA  AA    *YYY   YYY
    *BB   BBB         *DD   DDD      *AA  AA     *YYY YYY
    *BB  BBB  *IRTH*  *DD    DDD     *AA  AA      *YYYYY
    *BBBBB    *IRTH*  *DD    DDD     *AAAAAA       *YYY
    *BB  BBB  *IRTH*  *DD    DDD     *AA  AA       *YYY
    *BB   BBB         *DD   DDD      *AA  AA       *YYY
    *BB  BBB          *DD  DDD       *AA  AA       *YYY
    *BBBBB            *DDDDD         *AA  AA       *YYY
    
# What I need to use it?
Reddit account with 15 or more Karma points

# Ok, but how to use it then?

1 - You need a Microsoft Visual Studio e.g 2015/2017

2 - You need to download and open this project

3 - Insert Login, Password and Subreddit name

3.1 - Compile whole project and then insert your account informations via Console.Application input (e.g your keyboard)

4 - Let it work and pray that you won't send requests too fast because it may crash because of it
I have to do some kind of workaround to avoid this :P

# soon™

Avoiding Reddit's RateLimit Error

Additional functions such as replying to comments with specific words in their comments e.g

"!weather berlin" would reply to him with the weather in berlin today.
