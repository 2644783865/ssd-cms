using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for ArticleDetails.xaml
    /// </summary>
    public partial class ArticleDetails : MetroWindow
    {
        private ArticleDTO currentArticle;
        private List<SubmissionDTO> submissions = new List<SubmissionDTO>();
        private IArticleCore core;
        public ArticleDetails(ArticleDTO article)
        {
            InitializeComponent();
            core = new ArticleCore();
            currentArticle = article;
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "pdf files (*.pdf)|*.pdf"
            };

            if ((bool)fileDialog.ShowDialog())
            {
                var articleFile = ReadData(File.OpenRead(fileDialog.FileName));
                var submission = new SubmissionDTO()
                {
                    SubmissionDate = DateTime.Now,
                    ArticleFile = articleFile,
                    ArticleId = currentArticle.ArticleId
                };
                await core.AddSubmissionAsync(submission);
            }
        }

        private byte[] ReadData(Stream data)
        {
            var reader = new BinaryReader(data);
            return reader.ReadBytes((int)data.Length);
        }

        private void PresentationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void View_Click(object sender, RoutedEventArgs e)
        {
            if (SubmissionBox.SelectedIndex >= 0)
            {
                var selectedSubmission = submissions.ElementAt(SubmissionBox.SelectedIndex);
                SaveFileDialog fileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "pdf files (*.pdf)|*.pdf",
                    FileName = $"{currentArticle.Topic} submission {selectedSubmission.SubmissionDate.ToShortDateString()}"
                };

                var submission = await core.GetSubmissionByIdAsync(selectedSubmission.SubmissionID);
                if ((bool)fileDialog.ShowDialog())
                {
                    WriteData(fileDialog.FileName, submission.ArticleFile);
                }
            }
            else MessageBox.Show("Select submission");
        }

        private void WriteData(string fileName, byte[] bytes)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.CreateNew)))
            {
                writer.Write(bytes);
            }
        }

        private void Reviews_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddReview_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
