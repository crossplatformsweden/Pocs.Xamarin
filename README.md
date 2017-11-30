# Pocs.Xamarin
Contains small POC projects that would be used as a reference 

## Modularity
### What can you see here ? 
1. Prism
2. PrismModularity
3. Unity 
3. Navigation Service
4. EventAggregator 


### 100% agnostic modules
This project is a poc of using Modularity with Prism.  It is also a POC of total agnosity  of the modules by the use of 
events to move between modules. These events are handled by a centralised component which will navigate between the modules accourding to the 
event received.

**Example**

Imagine that you have two Modules: Authentication Module and MainModule. When the user signs in successfully, the app would navigate
from Authentication Module to the *MainPage* in the MainModule. Usually the code inside AuthenticationViewModel for this is something like 
```csharp
await _navigationService.NavigateAsync("MainPage"); 
```

The problem with this code is AuthenticationModule will have a code about where to go next.  

So the solution here is that instead of the module says where to go next after something happening, the module says that the event happened 
and it is up to the ```EventHandlerService``` to decide where to go next.   

### Hints Learned 
1. Use the Prism Template Extension as it has the feature to add modules 
2. Make sure that you are on the latest and greatest of Xamarin.Forms and Prism. 
3. We tried to use DryIOC but it did not really work so we went back to Unity and that worked fine. 
4. If you have not migrated to netStandard , Do so 
 
