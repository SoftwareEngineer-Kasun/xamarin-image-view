ImageView image1 = FindViewById<ImageView> (Resource.Id.imageView1);
 imgView.SetImageBitmap(bm);
 
 
 //load image from net
 private async Task<Bitmap> GetImageFromUrl(string url)
{
    using(var client = new HttpClient())
    {
        var msg = await client.GetAsync(url);
        if (msg.IsSuccessStatusCode)
        {
            using(var stream = await msg.Content.ReadAsStreamAsync())
            {
                ﻿var bitmap = await BitmapFactory.DecodeStreamAsync(stream);
                return bitmap;
            }
        }
    }
    return null;
}

//return

var imgView = FindViewById<ImageView>(Resource.Id.MyImageView);
using(var bm = await GetImageFromUrl("your url here"))    
    imgView.SetImageBitmap(bm);

