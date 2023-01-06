using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    public GameObject messagePanelPrefab; // A prefab for the UI panel to hold a message
    public Transform messageContainer; // A container for the message panels
    public Image playerImage; // An image to indicate the player sender
    public Image npcImage; // An image to indicate the NPC sender
    public InputField inputField; // A UI input field for the player to enter their message

    // A data structure to store the conversation history
    private List<Message> conversationHistory = new List<Message>();

    // A class to represent a message
    [Serializable]
    private class Message
    {
        public bool isPlayer; // Whether the message is from the player
        public string text; // The message text
        public float timestamp; // The timestamp of the message
    }

    // Add a message to the conversation history and display it in the chatbox
    public void AddMessage(bool isPlayer, string text, [NotNull] Image senderImage)
    {
        if (senderImage == null) throw new ArgumentNullException(nameof(senderImage));
        // Create a new message object
        Message message = new Message();
        message.isPlayer = isPlayer;
        message.text = text;
        message.timestamp = Time.time;

        // Add the message to the conversation history
        conversationHistory.Add(message);

        // Instantiate a new message panel prefab and set its properties
        GameObject messagePanel = Instantiate(messagePanelPrefab, messageContainer, false);
        Text messageText = messagePanel.transform.Find("Text").GetComponent<Text>();
        messageText.text = text;
        senderImage = messagePanel.transform.Find("Sender Image").GetComponent<Image>();
        senderImage.sprite = isPlayer ? playerImage.sprite : npcImage.sprite;

        // Scroll the chatbox to the bottom to display the latest message
        ScrollRect scrollRect = messageContainer.GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = 0;
    }

    // Send the player's message to the NPC
    public void SendMessage()
    {
        // Get the message from the input field
        string message = inputField.text;

        // Add the player's message to the conversation history and display it in the chatbox
        AddMessage(true, message, playerImage);

        // Clear the input field
        inputField.text = "";

        // TODO:

    }
}
