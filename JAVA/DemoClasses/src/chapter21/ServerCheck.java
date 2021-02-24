package com.java24hours;

import java.io.*;
import java.net.*;
import java.util.*;
import jdk.incubator.http.*;

public class ServerCheck {
    public ServerCheck() {
        String[] sites = {
            "https://www.apple.com",
            "https://www.microsoft.com",
            "http://www.compaq.com",
            "http://www.hp.com",
            "https://www.oracle.com/",
            "http://www.informit.com/"
        };
        try {
            load(sites);
        } catch (URISyntaxException oops) {
            System.out.println("Bad URI: " + oops.getMessage());
        } catch (IOException | InterruptedException oops) {
            System.out.println("Error: " + oops.getMessage());
        }
    }
    
    public void load(String[] sites) throws URISyntaxException, IOException,
            InterruptedException {
        
        for (String site : sites) {
            System.out.println("\nSite: " + site);
            // create the web client
            HttpClient browser = HttpClient.newHttpClient();
            // build a request for a website
            URI uri = new URI(site);
            HttpRequest.Builder bob = HttpRequest.newBuilder(uri);
            HttpRequest request = bob.build();
            // execute the request
            HttpResponse<String> response = browser.send(request,
                HttpResponse.BodyHandler.asString());
            // look for a server header
            HttpHeaders headers = response.headers();
            Optional<String> server = headers.firstValue("Server");
            if (server.isPresent()) {
                System.out.println("Server: " + server.get());
            } else {
                System.out.println("Server unidentified");
            }
        }
    }
    
    public static void main(String[] arguments) {
        new ServerCheck();
    }
}
