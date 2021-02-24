package com.java24hours;

import java.io.*;
import java.net.*;
import java.nio.file.*;
import jdk.incubator.http.*;

public class ImageDownloader {
    public ImageDownloader() {
        String uri = "http://workbench.cadenhead.org/media/lighthouse.jpg";
        try {
            load(uri);
        } catch (URISyntaxException oops) {
            System.out.println("Bad URI: " + oops.getMessage());
        } catch (IOException | InterruptedException oops) {
            System.out.println("Error: " + oops.getMessage());
        }
    }
    
    public void load(String imageUri) throws URISyntaxException, IOException,
        InterruptedException {
        
            // create the web client
            HttpClient browser = HttpClient.newHttpClient();
            // build a request for the image
            URI uri = new URI(imageUri);
            HttpRequest.Builder bob = HttpRequest.newBuilder(uri);
            HttpRequest request = bob.build();
            // create a file to hold the image data
            Path temp = Files.createTempFile("lighthouse", ".jpg");
            // execute the request and retrieve the data
            HttpResponse<Path> response = browser.send(request,
                HttpResponse.BodyHandler.asFile(temp));
            System.out.println("Image saved to "
                + temp.toFile().getAbsolutePath());
            // save the file permanently
            File perm = new File("lighthouse.jpg");
            temp.toFile().renameTo(perm);            
            System.out.println("Image moved to " + perm.getAbsolutePath());
    }
    
    public static void main(String[] arguments) {
        new ImageDownloader();
    }
}
