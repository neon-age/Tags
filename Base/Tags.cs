using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("GameObject/Tags")]
[HelpURL("")]
public class Tags : MonoBehaviour
{
    [SerializeField] private List<Tag> tags;

    private void Awake()
    {
	    foreach (var tag in tags)
		    gameObject.RegisterGameObjectWithTag(tag);
    }

    public List<Tag> GetTags()
    {
        return tags;
    }

    public void SetTags(params Tag[] tags)
    {
        this.tags = tags.ToList();
    }
}
