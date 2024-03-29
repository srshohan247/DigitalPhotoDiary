﻿using DigitalPhotoDiary.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DigitalPhotoDiary.BusinessLayer;

namespace DigitalPhotoDiary.PresentationLayer
{
    public partial class EventDisplayPanel : Form
    {
        public EventDisplayPanel( int eventId, string name, string date, string modDate, int userId, string userName)
        {
            InitializeComponent();
            userNameLabel.Text = userName;
            userIdLabel.Text = Convert.ToString(userId);
            eventIdLabel.Text = Convert.ToString(eventId);
            eventNameLabel.Text = name;
            modificationDateLabel.Text = modDate +" (modified)";
            dateLabel.Text = date;
        }


        private void homeBackButton_Click(object sender, EventArgs e)
        {
            HomePanel homePanel = new HomePanel(Convert.ToInt32(userIdLabel.Text), userNameLabel.Text);
            this.Hide();
            homePanel.Show();
        }

        private void EventDisplayPanel_Load(object sender, EventArgs e)
        {
            try {
                UpdatePhoto1();
                
            }
            catch (Exception exp) { }
            try
            {
                
                UpdatePhoto2();
                
            }
            catch (Exception exp) { }
            try
            {
                
                UpdateStory1();
               
            }
            catch (Exception exp) { }
            try
            {
                UpdateStory2();
            }
            catch (Exception exp) { }
        }

        private void EventDisplayPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void storyTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void storyGroypBox_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        void UpdatePhoto1()
        {
            PhotoService photoService = new PhotoService();
            Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo1");
            if (photo.Directory != null)
            {
                pictureBox1.Image = Image.FromFile(photo.Directory);
                //storyLabel1.Text = photo.Story;
            }

        }
        void UpdatePhoto2()
        {
            PhotoService photoService = new PhotoService();
            Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo2");
            if (photo.Directory != null)
            {
                pictureBox2.Image = Image.FromFile(photo.Directory);
                //storyLabel1.Text = photo.Story;
            }
            else { }

        }
        void UpdateStory1()
        {
            PhotoService photoService = new PhotoService();
            Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo1");
            if (photo.Story != null)
            {
                storyLabel1.Text = photo.Story;
            }
            else { }
        }
        void UpdateStory2()
        {
            PhotoService photoService = new PhotoService();
            Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo2");
            if (photo.Story != null)
            {
                storyLabel2.Text = photo.Story;
            }
            else { }
        }
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openedFileDialog = new OpenFileDialog();
            if (openedFileDialog.ShowDialog() == DialogResult.OK) { pathTextBox1.Text = openedFileDialog.FileName; }
            //openedFileDialog.
        }

        private void browseButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openedFileDialog = new OpenFileDialog();
            if (openedFileDialog.ShowDialog() == DialogResult.OK) { pathTextBox2.Text = openedFileDialog.FileName; }
        }

        private void addPhotoButton1_Click(object sender, EventArgs e)
        {
            /* PhotoService photoService = new PhotoService();
             Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo1");
             photoService = null;
             if (photo == null)
             {
                 PhotoService photoService1 = new PhotoService();
                 string stor = @"D:\Documents\Programming\C#\DigitalPhotoDiary\DigitalPhotoDiary\Storage\photo1.png";
                 File.Copy(pathTextBox1.Text, stor, true);
                 pictureBox1.Image = Image.FromFile(stor);
                 int result = photoService1.AddNewPhoto("photo1", stor, null, Convert.ToInt32(eventIdLabel.Text));
                 if (result > 0)
                 {
                     MessageBox.Show("Added!");
                     pathTextBox1.Text = "Photo1";
                     EventsService eventsService = new EventsService();
                     eventsService.UpdateDate(Convert.ToInt32(eventIdLabel.Text), DateTime.Now.ToString("u"));
                 }
                 else { MessageBox.Show("Something Wrong!"); }
             }
             else { MessageBox.Show("You have Already Added!"); }*/
            PhotoService photoService = new PhotoService();
            Photo p = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo1");
            photoService = null;
            if (p == null)
            {
                PhotoService photoService1 = new PhotoService();
                string stor = pathTextBox1.Text; //@"D:\Documents\Programming\C#\DigitalPhotoDiary\DigitalPhotoDiary\Storage\photo2.png";
                                                 //File.Copy(pathTextBox2.Text, stor, true);
                pictureBox1.Image = Image.FromFile(stor);
                int result = photoService1.AddNewPhoto("photo1", stor, null, Convert.ToInt32(eventIdLabel.Text));
                if (result > 0)
                {
                    MessageBox.Show("Added!");
                    pathTextBox1.Text = "Photo1";
                    EventsService eventsService = new EventsService();
                    eventsService.UpdateDate(Convert.ToInt32(eventIdLabel.Text), DateTime.Now.ToString("u"));
                }
                else { MessageBox.Show("Something Wrong!"); }
            }
            else { MessageBox.Show("You have Already Added!"); }
        }

        private void addPhotoButton2_Click(object sender, EventArgs e)
        {
            PhotoService photoService = new PhotoService();
            Photo p = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo2");
            photoService = null;
            if (p == null) {
                PhotoService photoService1 = new PhotoService();
                string stor = pathTextBox2.Text; //@"D:\Documents\Programming\C#\DigitalPhotoDiary\DigitalPhotoDiary\Storage\photo2.png";
                 //File.Copy(pathTextBox2.Text, stor, true);
                pictureBox2.Image = Image.FromFile(stor);
                int result = photoService1.AddNewPhoto("photo2", stor, null, Convert.ToInt32(eventIdLabel.Text));
                if (result > 0)
                {
                    MessageBox.Show("Added!");
                    pathTextBox2.Text = "Photo2";
                    EventsService eventsService = new EventsService();
                    eventsService.UpdateDate(Convert.ToInt32(eventIdLabel.Text), DateTime.Now.ToString("u"));
                }
                else { MessageBox.Show("Something Wrong!"); }
            }
            else { MessageBox.Show("You have Already Added!"); }
        }

        private void updatePhotoButton1_Click(object sender, EventArgs e)
        {
            if (pathTextBox2.Text != "photo1") {
                PhotoService photoService = new PhotoService();
                Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo1");
                photoService = null;
                PhotoService photoService1 = new PhotoService();
                int result = photoService1.UpdatePhoto(pathTextBox1.Text, photo.PhotoId);
                if (result > 0)
                {
                    MessageBox.Show("Updated!");
                    pictureBox1.Image = Image.FromFile(pathTextBox1.Text);
                    pathTextBox1.Text = null;
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!");
                }
            }
        }

        private void updatePhotoButton2_Click(object sender, EventArgs e)
        {
            if (pathTextBox2.Text != "photo2") { PhotoService photoService = new PhotoService();
                Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo2");
                photoService = null;
                PhotoService photoService1 = new PhotoService();
                int result = photoService1.UpdatePhoto(pathTextBox2.Text, photo.PhotoId);
                if (result > 0)
                {
                    MessageBox.Show("Updated!");
                    pictureBox2.Image = Image.FromFile(pathTextBox2.Text);
                    pathTextBox2.Text = null;
                }
                else {
                    MessageBox.Show("Something Went Wrong!");
                }
            }
        }

        private void addStoryButton1_Click(object sender, EventArgs e)
        {
            PhotoService photoService = new PhotoService();
            Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo1");
            photoService = null;
            PhotoService photoService1 = new PhotoService();
            int result = photoService1.UpdateStory(storyTextBox1.Text, photo.PhotoId);
            if (result > 0) { 
                MessageBox.Show("Story Added!");
                storyLabel1.Text = storyTextBox1.Text;
                storyTextBox1.Text = null;
                EventsService eventsService = new EventsService();
                eventsService.UpdateDate(Convert.ToInt32(eventIdLabel.Text), DateTime.Now.ToString("u"));
            }
            else { MessageBox.Show("Something Wrong!"); }
        }

        private void addStoryButton2_Click(object sender, EventArgs e)
        {
            PhotoService photoService = new PhotoService();
            Photo photo = photoService.GetPhoto(Convert.ToInt32(eventIdLabel.Text), "photo2");
            photoService = null;
            PhotoService photoService1 = new PhotoService();
            int result = photoService1.UpdateStory(storyTextBox2.Text, photo.PhotoId);
            if (result > 0)
            {
                MessageBox.Show("Story Added!");
                storyLabel2.Text = storyTextBox2.Text;
                storyTextBox2.Text = null;
                EventsService eventsService = new EventsService();
                eventsService.UpdateDate(Convert.ToInt32(eventIdLabel.Text), DateTime.Now.ToString("u"));
            }
            else { MessageBox.Show("Something Wrong!"); }
        }
    }
}
