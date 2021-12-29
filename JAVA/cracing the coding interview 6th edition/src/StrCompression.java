import java.util.HashMap;
import java.util.Map;

public class StrCompression {

	public static void main(String[] args) {
		/*
		 * String Compression: Implement a method to perform basic string compression
		 * using the counts of repeated characters. For example, the string aabcccccaaa
		 * would become a2blc5a3. If the "compressed" string would not become smaller
		 * than the original string, your method should return the original string. You
		 * can assume the string has only uppercase and lowercase letters (a - z).
		 */

		var str = "aabcccccaaa";

		// full compression do not match the upper condition
		Map<Character, Integer> map = new HashMap<Character, Integer>();

		for (int i = 0; i < str.length(); i++) {
			var ch = str.charAt(i);

			if (map.containsKey(ch)) {
				int count = map.getOrDefault(ch, 0); // ensure count will be one of 0,1,2,3,...
				map.put(ch, count + 1);
			} else {
				map.put(ch, 1);
			}
		}

		for (var kvp : map.entrySet()) {
			System.out.printf("%s%d", kvp.getKey(), kvp.getValue());
		}
		
		System.out.println();

		// part compression
		var prev = str.charAt(0);
		var counter = 1;
		var sb=new StringBuilder();
		for (int i = 1; i < str.length(); i++) {
			if (prev == str.charAt(i)) {
				prev=str.charAt(i);
				counter++;
			} else {
				sb.append(String.valueOf(prev)+counter);
				prev=str.charAt(i);
				counter=1;
			}
		}
		
		sb.append(String.valueOf(prev)+counter);
		
		System.out.println(sb);
	}

}
