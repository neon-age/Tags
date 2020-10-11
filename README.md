# Tags
Replacement of built-in tags with asset-based solution.\
It's easier for collaboration and fun to work with!

![Multiple Tags](https://i.imgur.com/dq55rak.png) 
>*Create/GameObject/Tag*\
>*Add Component/GameObject/Tags*

![Multiple Tags](https://i.imgur.com/1Vp1gvB.png)\
Tag name matters only to you now.

___

### Tests:
- FindWithTag is faster, as it's just a lookup for reference\
![FindWithTagTest](https://i.imgur.com/fVgO4z4.png)
>*tested in Update with 720 objects, 72B allocation comes from IEnumerable on FindAllWithTag*
