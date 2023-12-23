// #if UNITY_EDITOR
// using UnityEditor;

// [CustomEditor(typeof(Interactable), true)]
// public class InteractableEditor : Editor
// {

//     public override void OnInspectorGUI()
//     {
//         Interactable interactable = (Interactable)target;
//         if (target.GetType() == typeof(EventOnlyInteractable))
//         {
//             interactable.PromptMessage = EditorGUILayout.TextField("Prompt Message", interactable.PromptMessage);
//             EditorGUILayout.HelpBox("EventOnlyInteractable can ONLY use Unity Events", MessageType.Info);
//             if (interactable.GetComponent<InteractionEvents>() == null)
//             {
//                 interactable.useEvents = true;
//                 interactable.gameObject.AddComponent<InteractionEvents>();
//             }
//         }
//         base.OnInspectorGUI();
//         if (interactable.useEvents)
//         {
//             if (interactable.GetComponent<InteractionEvents>() == null)
//                 interactable.gameObject.AddComponent<InteractionEvents>();

//         }
//         else
//         {
//             if (!interactable.GetComponent<InteractionEvents>() != null)
//                 DestroyImmediate(interactable.GetComponent<InteractionEvents>());
//         }
//     }
// }
// #endif