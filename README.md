# FLAG READER
An Augmented Reality App to Identify countries flags and display in the screen information about that country.

It was an university assignment to test my knowledge and my usage of AR, Unity and C#. I had two weeks to plan the app and draft the documentation and an extra two weeks to develop the app, finish the [documentation](Augmented_Reality_application_make_students_more_interested_in_learning.pdf) and attach a study case using the app to the report.


## APK

[Download APK](/FlagRecognition.apk)

## How to use
1. Open the app and point to any of the following country flags:

obs: You can also open the file [Test_Questionnaire.pdf](/Test_Questionnaire.pdf) which contain all the flags supported at the moment.

Albania, Brazil, Canada, Croatia, Eswatini, Fiji, India, Kazakhstan, Kenya, Malaysia, Mexico, Mongolia, New Zealand, Papua New Guinea, Peru, Portugal, Saudi Arabia, Slovakia, Spain, Sri Lanka and Zimbabwe.


## Reflection
- I found that flags are not the best images to be triggered. Simple flags (without symbols and form) cannot be triggered, such as Japan and Thailand.  
- I also found that most of the Image recognition technolgies convert the image to black and white and just trigger depending on the image vectors.

##### Why not Vuforia
Initially, the plan was to use Vuforia because that was the technology I learnt on the classes. However, when I started implementing the code and triggering the flags I realised Vuforia wouldn't recognize flags very well. So, I decided to use a few different technologies and compare which one would be the best for this project. 

##### Why not Google ARCore
After Vuforia, I thought Google ARCore would be the best and most advanced option for Image Recognition, however, it ended up having the lowest performace in my comparison test. It was also the hardest technology to implement.

#### Why EasyAR
I ran the same test, with the same flags, and it had the best performance (find results below). It was still not 100%, but it was very close to the results I was looking for. Also, it had the easiest way of implementation, even though the documentation wasn't very good at that moment.

| Flags country | Vuforia | ARCore | EasyAR    |
| ------------- |:-------:|:------:|:---------:|
| Australia     | Yes*    | No     | Yes*      |
| Brazil        | Yes     | No     | Yes       |
| Fiji          | No      | Yes    | Yes       |
| Japan         | No      | No     | No        |
| New Zealand   | Yes     | No     | Yes*      |
| Thailand      | No      | No     | No        |
| USA           | No      | No     | Sometimes |
*Australian and New Zealand flags can be mistaken as a result of their similarities. 

---
- To fulfill my needs of having an app to tell me which flag I am looking at when I don't know, I developed the [Flag Finder App for Web](https://github.com/felipe-mapa/flag-finder-web) and the [Flag Finder App for Mobile](https://github.com/felipe-mapa/flag-finder-mob) with React/React Native