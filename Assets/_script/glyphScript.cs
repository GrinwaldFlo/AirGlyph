using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class glyphScript : MonoBehaviour
{
	public string glyphName = "";
	private string actualGlyphName = "";
	Dictionary<int, GameObject> lstSeg;


	// Use this for initialization
	void Start()
	{
		lstSeg = new Dictionary<int, GameObject>(this.transform.childCount);

		for (int i = 0; i < transform.childCount; i++)
		{
			int curId = 0;
			if(int.TryParse(transform.GetChild(i).name, out curId))
			{
				lstSeg.Add(curId, transform.GetChild(i).gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(glyphName != actualGlyphName)
		{
			actualGlyphName = glyphName;
			clGlyph foundGlyph;
			if (Gvar.dicGlyph.TryGetValue(glyphName.ToLower(), out foundGlyph))
			{
				setGlyph(foundGlyph);
			}
			else
			{
				foreach (KeyValuePair<int, GameObject> item in lstSeg)
				{
					item.Value.SetActive(true);
				}
			}
		}
	}

	private void setGlyph(clGlyph foundGlyph)
	{
		foreach (KeyValuePair<int, GameObject> item in lstSeg)
		{
			item.Value.SetActive(false);
		}

		for (int i = 0; i < foundGlyph.pattern.Length; i++)
		{
			lstSeg[foundGlyph.pattern[i]].SetActive(true);
		}
	}
}
