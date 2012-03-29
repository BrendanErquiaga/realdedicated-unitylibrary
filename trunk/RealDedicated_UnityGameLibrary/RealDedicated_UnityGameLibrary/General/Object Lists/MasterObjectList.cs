﻿using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    /// <summary>
    /// This class contains all of there RefrenceableObjectLists found in a Scene. 
    /// </summary>
    public class MasterObjectList : ReferencableObjectList
    {
        #region Static Instance
        private static MasterObjectList classInstance = null;

        public static MasterObjectList instance
        {
            get
            {
                if (classInstance == null)
                {
                    classInstance = FindObjectOfType(typeof(MasterObjectList)) as MasterObjectList;
                }

                if (classInstance == null)
                {
                    GameObject newObj = new GameObject("MasterObjectList");
                    classInstance = newObj.AddComponent(typeof(MasterObjectList)) as MasterObjectList;
                    Debug.Log("Could not find MasterObjectList, so I made one");
                }

                return classInstance;
            }
        }
        #endregion

        protected override void GetObjects()
        {
            base.GetObjects();

            ReferencableObjectList[] tempObjectLists = this.gameObject.GetComponents<ReferencableObjectList>();
            ReferencableObject[] tempRefObjects = new ReferencableObject[tempObjectLists.Length];

            for (int i = 0; i < tempRefObjects.Length; i++)
            {
                tempRefObjects[i] = new ReferencableObject();
                tempRefObjects[i].ObjectName = tempObjectLists[i].ObjectListName;
                tempRefObjects[i].ObjectToReference = tempObjectLists[i];
            }

            this.Objects = new ReferencableObject[tempRefObjects.Length];
            this.Objects = tempRefObjects;
        }

        /// <summary>
        /// Retrieve ObjectList by name 
        /// </summary>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual ReferencableObjectList RetrieveObjectList(string nameOfObjectList)
        {
            ReferencableObjectList tempObjectList = null;

            foreach (ReferencableObject childObject in this.Objects)
            {
                if (childObject.ObjectName == nameOfObjectList)
                {
                    tempObjectList = childObject.ObjectToReference as ReferencableObjectList;
                    break;
                }
            }

            return tempObjectList;
        }

        /// <summary>
        /// Retrieve ReferenceableObject By Name from List by Name.
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual ReferencableObject RetrieveObject(string nameOfObject, string nameOfObjectList)
        {
            ReferencableObject tempObject = null;

            foreach (ReferencableObject childObject in this.Objects)
            {
                if (childObject.ObjectName == nameOfObjectList)
                {
                    ReferencableObjectList childObjectsList = childObject.ObjectToReference as ReferencableObjectList;

                    foreach (ReferencableObject childObjectsItem in childObjectsList.Objects)
                    {
                        if (childObjectsItem.ObjectName == nameOfObjectList)
                        {
                            tempObject = childObjectsItem;
                            break;
                        }
                    }
                }
            }

            return tempObject;
        }

        /// <summary>
        /// Retrieve Actual Object By Name from List by Name.
        /// </summary>
        /// <param name="nameOfObject">Name of Object</param>
        /// <param name="nameOfObjectList">Name of ObjectList</param>
        /// <returns></returns>
        public virtual Object RetrieveObjectActual(string nameOfObject, string nameOfObjectList)
        {
            return this.RetrieveObject(nameOfObject,nameOfObjectList).ObjectToReference;
        }
    }
}
