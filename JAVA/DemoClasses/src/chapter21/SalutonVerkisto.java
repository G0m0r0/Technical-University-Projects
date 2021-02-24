package com.java24hours;

import java.io.*;
import java.net.*;
import jdk.incubator.http.*;

public class SalutonVerkisto {
    
    public SalutonVerkisto() {
        String site = "http://workbench.cadenhead.org/post-a-comment.php";
        try {
            postMessage(site);
        } catch (URISyntaxException oops) {
            System.out.println("Bad URI: " + oops.getMessage());
        } catch (IOException | InterruptedException oops) {
            System.out.println("Error: " + oops.getMessage());
        }
    }
    
    public void postMessage(String server) throws IOException,
            URISyntaxException, InterruptedException {
        
        HttpClient client = HttpClient.newHttpClient();

        // address of the server
        URI uri = new URI(server);
        
        // set up the message
        String yourName = "Sam Snett of Indianapolis";
        String yourMessage = "Your book is pretty good, if I do say so myself.";
        
        // encode the message
        HttpRequest.BodyProcessor proc = HttpRequest.BodyProcessor.fromString(
            "name=" + URLEncoder.encode(yourName, "UTF-8") +
            "&comment=" + URLEncoder.encode(yourMessage, "UTF-8") +
            "&mode=" + URLEncoder.encode("demo", "UTF-8")
        );
        
        // prepare the request
        HttpRequest.Builder newBuilder = HttpRequest.newBuilder(uri)
            .header("Content-Type", "application/x-www-form-urlencoded")
            .header("Accept", "text/plain")
            .POST(proc);
        
        // finish the request
        HttpRequest request = newBuilder.build();
        
        // get the response from the server
        System.out.println("Method: " + request.method() + "\n");
        HttpResponse<String> response = client.send(request,
            HttpResponse.BodyHandler.asString());
        System.out.println(response.body());
    }

    public static void main(String[] arguments) {
        new SalutonVerkisto();
    }
}
