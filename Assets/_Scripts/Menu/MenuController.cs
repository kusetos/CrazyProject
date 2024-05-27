using System.Collections;
using System.Collections.Generic;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Page InitialPage;
    [SerializeField]
    private GameObject FirstFocusItem;

    private Canvas RootCanvas;
    private Stack<Page> PageStack = new Stack<Page>();

    private void Awake()               
    {
        RootCanvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        if(FirstFocusItem != null)
        {
            EventSystem.current.SetSelectedGameObject(FirstFocusItem);
        }
    }
    private void OnCancel()
    {
        if (RootCanvas.enabled && RootCanvas.gameObject.activeInHierarchy)
        {
            if (PageStack.Count != 0)
            {
                PopPage();
            }
        }
    }



    public void PushPage(Page page)
    {
        page.Enter(true);
        
        if(PageStack.Count > 0 )
        {
            Page currentPage = PageStack.Peek();
            if(currentPage.ExitOnNewPagePush)
            {
                currentPage.Exit(false);
            }
        }

    }
    public bool IsPageInStack(Page Page)
    {
        return PageStack.Contains(Page);
    }

    public bool IsPageOnTopOfStack(Page Page)
    {
        return PageStack.Count > 0 && Page == PageStack.Peek();
    }
    public void PopPage()
    {
        if(PageStack.Count > 1)
        {
            Page page = PageStack.Pop();
            page.Exit(true);
            
            Page newCurrentPage = PageStack.Peek();
            if (newCurrentPage.ExitOnNewPagePush)
            {
                newCurrentPage.Exit(false);
            }
        }
        else
        {
            Debug.LogWarning("1 page, No POP");
        }
    }
    public void PopAllPages()
    {
        for (int i = 1; i < PageStack.Count; i++)
        {
            PopPage();
        }
    }

}
