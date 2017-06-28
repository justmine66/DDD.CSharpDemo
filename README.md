### 1、引言
   想好好学习DDD，但苦于一直没有找到一本好的书籍或理论综述，之前一直在developeriq上，碎片化的学习相关概念（聚合根、值对象、实体等等），但总是不过瘾，旺盛的求知欲总是无法得到持续性的满足，无意之中浏览了大师Martin Fowler的书籍《Patterns of Enterprise Application Architecture》，发现这就是我一直在寻找的东西。于是准备系统性的学习一下，由于书中给予的都是些伪代码，有的是用java写的，为了能够通透的理解，每学习的一种模式，决定都写上CSharp的示例代码，作为对知识的巩固，也方便以后的查阅，同时也为此书贡献一份C#示例，如有不当，欢迎指正，欢迎交流。
   > 英文目录 https://www.martinfowler.com/eaaCatalog/
### 2、场景
   由于本书基本采用同一种问题描述来解释相关领域的模式，故在此作一个统一的说明。
   > 问题描述：
       收入确认是商业系统中一个常见的问题，关心的是何时讲所收的钱入账，如果我卖给你一杯咖啡，收入确认就很简单了，我给你咖啡，收钱，然后立即将钱入账，但是许多交易中的收入确认却很负责，例如：你给我一笔预聘费，让我为你提供一年的顾问服务，即使你今天就给了我这笔钱，我可能仍然不能立即入账，因为完成服务需要一年时间，可能一个月以后你意识到作为写作的我的编程技术退化了，于是取消这以合同，解决办法就是没月讲预聘费1/12入账。
       收入确认的规则种类繁多而且异变，这些规则有的是由法律决定，有的是由行规决定，有的是由公司的经营政策决定，收入跟踪变成了一个十分复杂的问题。
       假定某公司出售三种产品：文字处理软件、电子表格软件、数据库软件；根据规则，当签下一个售出文字软件的合同时，所有收入可以立即入账；当签下一个售出电子表格软件的合同时，当天入账1/3；60天后再入账1/3；剩下的1/3，90天时入账；当签下一个售出数据库软件的合同时，当天入账1/3；30天后再入账1/3；剩下的1/3，60天时入账。
