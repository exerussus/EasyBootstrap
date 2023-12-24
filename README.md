# EasyBootstrap
Данное решение объединяет в себе несколько архитектурных паттернов для лёгкого старта без лишних раздумий над устройством небольших проектов.


## Functionality
Решение создаёт единую точку входа для MonoBehaviours с возможностью регулирования порядка в инспекторе, а так же получая информацию о итоговом порядке загрузки. 
Для этого класс должен наследовать EasyMonoBehaviour вместо обычного MonoBehaviour и использовать метод Initialize вместо Start или Awake.


 [![](https://i.ibb.co/YXKhq2x/Screenshot-8.png)]()



 Порядок загрузки можно наблюдать в Boot Queue.

 
 [![](https://i.ibb.co/C2ZSsm7/Screenshot-9.png)]()


 Так же, есть возможность получать любой класс, который был активирован в Bootstrap через метод GetSharedData прямо в классе-наследнике EasyMonoBehaviour.


 ``` c#
public class TesterOrigin : EasyMonoBehaviour
    {
        private TesterTarget _target;
        private TesterAnotherTarget _testerAnotherTarget;
        
        public override void Initialize()
        {
            _target = GetSharedData<TesterTarget>();
            _testerAnotherTarget = GetSharedData<TesterAnotherTarget>();
        }
    }
```

Отследить зависимости, а именно какой класс в каком порядке вызывает другие классы, можно в поле GameShare.



[![](https://i.ibb.co/7KNqDF9/Screenshot-11.png)]()


Порядок для получения класса не важен. То есть, если в примере Target будет загружен только после Origin - сам Origin класс всё равно сможет получить его через GetShareData.
При этом в Bootstrap <strong>классы ДОЛЖНЫ БЫТЬ УНИКАЛЬНЫМИ</strong> (например, нельзя добавить два TesterOrigin). Если требуется инициализировать множество однотипных классов -
создайте класс EasyMonoBehaviour, которых будет овтечать за это. Если вам не нужно инициализировать класс, а только нужно "поделиться" им - закидывайте его в поле Share.
 
