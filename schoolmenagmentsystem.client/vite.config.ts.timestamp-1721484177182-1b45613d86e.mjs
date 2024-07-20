// vite.config.ts
import { fileURLToPath, URL } from "node:url";
import { defineConfig } from "file:///D:/SchoolMenagmentSystem/schoolmenagmentsystem.client/node_modules/vite/dist/node/index.js";
import plugin from "file:///D:/SchoolMenagmentSystem/schoolmenagmentsystem.client/node_modules/@vitejs/plugin-vue/dist/index.mjs";
import fs from "fs";
import path from "path";
import child_process from "child_process";
var __vite_injected_original_import_meta_url = "file:///D:/SchoolMenagmentSystem/schoolmenagmentsystem.client/vite.config.ts";
var baseFolder = process.env.APPDATA !== void 0 && process.env.APPDATA !== "" ? `${process.env.APPDATA}/ASP.NET/https` : `${process.env.HOME}/.aspnet/https`;
var certificateArg = process.argv.map((arg) => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
var certificateName = certificateArg ? certificateArg.groups.value : "schoolmenagmentsystem.client";
if (!certificateName) {
  console.error("Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.");
  process.exit(-1);
}
var certFilePath = path.join(baseFolder, `${certificateName}.pem`);
var keyFilePath = path.join(baseFolder, `${certificateName}.key`);
if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
  if (0 !== child_process.spawnSync("dotnet", [
    "dev-certs",
    "https",
    "--export-path",
    certFilePath,
    "--format",
    "Pem",
    "--no-password"
  ], { stdio: "inherit" }).status) {
    throw new Error("Could not create certificate.");
  }
}
var vite_config_default = defineConfig({
  plugins: [plugin()],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", __vite_injected_original_import_meta_url))
    }
  },
  server: {
    proxy: {
      "^/weatherforecast": {
        target: "https://localhost:7290/",
        secure: false
      }
    },
    port: 5173,
    https: {
      key: fs.readFileSync(keyFilePath),
      cert: fs.readFileSync(certFilePath)
    }
  }
});
export {
  vite_config_default as default
};
//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAic291cmNlcyI6IFsidml0ZS5jb25maWcudHMiXSwKICAic291cmNlc0NvbnRlbnQiOiBbImNvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9kaXJuYW1lID0gXCJEOlxcXFxTY2hvb2xNZW5hZ21lbnRTeXN0ZW1cXFxcc2Nob29sbWVuYWdtZW50c3lzdGVtLmNsaWVudFwiO2NvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9maWxlbmFtZSA9IFwiRDpcXFxcU2Nob29sTWVuYWdtZW50U3lzdGVtXFxcXHNjaG9vbG1lbmFnbWVudHN5c3RlbS5jbGllbnRcXFxcdml0ZS5jb25maWcudHNcIjtjb25zdCBfX3ZpdGVfaW5qZWN0ZWRfb3JpZ2luYWxfaW1wb3J0X21ldGFfdXJsID0gXCJmaWxlOi8vL0Q6L1NjaG9vbE1lbmFnbWVudFN5c3RlbS9zY2hvb2xtZW5hZ21lbnRzeXN0ZW0uY2xpZW50L3ZpdGUuY29uZmlnLnRzXCI7aW1wb3J0IHsgZmlsZVVSTFRvUGF0aCwgVVJMIH0gZnJvbSAnbm9kZTp1cmwnO1xyXG5cclxuaW1wb3J0IHsgZGVmaW5lQ29uZmlnIH0gZnJvbSAndml0ZSc7XHJcbmltcG9ydCBwbHVnaW4gZnJvbSAnQHZpdGVqcy9wbHVnaW4tdnVlJztcclxuaW1wb3J0IGZzIGZyb20gJ2ZzJztcclxuaW1wb3J0IHBhdGggZnJvbSAncGF0aCc7XHJcbmltcG9ydCBjaGlsZF9wcm9jZXNzIGZyb20gJ2NoaWxkX3Byb2Nlc3MnO1xyXG5cclxuY29uc3QgYmFzZUZvbGRlciA9XHJcbiAgICBwcm9jZXNzLmVudi5BUFBEQVRBICE9PSB1bmRlZmluZWQgJiYgcHJvY2Vzcy5lbnYuQVBQREFUQSAhPT0gJydcclxuICAgICAgICA/IGAke3Byb2Nlc3MuZW52LkFQUERBVEF9L0FTUC5ORVQvaHR0cHNgXHJcbiAgICAgICAgOiBgJHtwcm9jZXNzLmVudi5IT01FfS8uYXNwbmV0L2h0dHBzYDtcclxuXHJcbmNvbnN0IGNlcnRpZmljYXRlQXJnID0gcHJvY2Vzcy5hcmd2Lm1hcChhcmcgPT4gYXJnLm1hdGNoKC8tLW5hbWU9KD88dmFsdWU+LispL2kpKS5maWx0ZXIoQm9vbGVhbilbMF07XHJcbmNvbnN0IGNlcnRpZmljYXRlTmFtZSA9IGNlcnRpZmljYXRlQXJnID8gY2VydGlmaWNhdGVBcmcuZ3JvdXBzLnZhbHVlIDogXCJzY2hvb2xtZW5hZ21lbnRzeXN0ZW0uY2xpZW50XCI7XHJcblxyXG5pZiAoIWNlcnRpZmljYXRlTmFtZSkge1xyXG4gICAgY29uc29sZS5lcnJvcignSW52YWxpZCBjZXJ0aWZpY2F0ZSBuYW1lLiBSdW4gdGhpcyBzY3JpcHQgaW4gdGhlIGNvbnRleHQgb2YgYW4gbnBtL3lhcm4gc2NyaXB0IG9yIHBhc3MgLS1uYW1lPTw8YXBwPj4gZXhwbGljaXRseS4nKVxyXG4gICAgcHJvY2Vzcy5leGl0KC0xKTtcclxufVxyXG5cclxuY29uc3QgY2VydEZpbGVQYXRoID0gcGF0aC5qb2luKGJhc2VGb2xkZXIsIGAke2NlcnRpZmljYXRlTmFtZX0ucGVtYCk7XHJcbmNvbnN0IGtleUZpbGVQYXRoID0gcGF0aC5qb2luKGJhc2VGb2xkZXIsIGAke2NlcnRpZmljYXRlTmFtZX0ua2V5YCk7XHJcblxyXG5pZiAoIWZzLmV4aXN0c1N5bmMoY2VydEZpbGVQYXRoKSB8fCAhZnMuZXhpc3RzU3luYyhrZXlGaWxlUGF0aCkpIHtcclxuICAgIGlmICgwICE9PSBjaGlsZF9wcm9jZXNzLnNwYXduU3luYygnZG90bmV0JywgW1xyXG4gICAgICAgICdkZXYtY2VydHMnLFxyXG4gICAgICAgICdodHRwcycsXHJcbiAgICAgICAgJy0tZXhwb3J0LXBhdGgnLFxyXG4gICAgICAgIGNlcnRGaWxlUGF0aCxcclxuICAgICAgICAnLS1mb3JtYXQnLFxyXG4gICAgICAgICdQZW0nLFxyXG4gICAgICAgICctLW5vLXBhc3N3b3JkJyxcclxuICAgIF0sIHsgc3RkaW86ICdpbmhlcml0JywgfSkuc3RhdHVzKSB7XHJcbiAgICAgICAgdGhyb3cgbmV3IEVycm9yKFwiQ291bGQgbm90IGNyZWF0ZSBjZXJ0aWZpY2F0ZS5cIik7XHJcbiAgICB9XHJcbn1cclxuXHJcbi8vIGh0dHBzOi8vdml0ZWpzLmRldi9jb25maWcvXHJcbmV4cG9ydCBkZWZhdWx0IGRlZmluZUNvbmZpZyh7XHJcbiAgICBwbHVnaW5zOiBbcGx1Z2luKCldLFxyXG4gICAgcmVzb2x2ZToge1xyXG4gICAgICAgIGFsaWFzOiB7XHJcbiAgICAgICAgICAgICdAJzogZmlsZVVSTFRvUGF0aChuZXcgVVJMKCcuL3NyYycsIGltcG9ydC5tZXRhLnVybCkpXHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuICAgIHNlcnZlcjoge1xyXG4gICAgICAgIHByb3h5OiB7XHJcbiAgICAgICAgICAgICdeL3dlYXRoZXJmb3JlY2FzdCc6IHtcclxuICAgICAgICAgICAgICAgIHRhcmdldDogJ2h0dHBzOi8vbG9jYWxob3N0OjcyOTAvJyxcclxuICAgICAgICAgICAgICAgIHNlY3VyZTogZmFsc2VcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0sXHJcbiAgICAgICAgcG9ydDogNTE3MyxcclxuICAgICAgICBodHRwczoge1xyXG4gICAgICAgICAgICBrZXk6IGZzLnJlYWRGaWxlU3luYyhrZXlGaWxlUGF0aCksXHJcbiAgICAgICAgICAgIGNlcnQ6IGZzLnJlYWRGaWxlU3luYyhjZXJ0RmlsZVBhdGgpLFxyXG4gICAgICAgIH1cclxuICAgIH1cclxufSlcclxuIl0sCiAgIm1hcHBpbmdzIjogIjtBQUF1VixTQUFTLGVBQWUsV0FBVztBQUUxWCxTQUFTLG9CQUFvQjtBQUM3QixPQUFPLFlBQVk7QUFDbkIsT0FBTyxRQUFRO0FBQ2YsT0FBTyxVQUFVO0FBQ2pCLE9BQU8sbUJBQW1CO0FBTjZMLElBQU0sMkNBQTJDO0FBUXhRLElBQU0sYUFDRixRQUFRLElBQUksWUFBWSxVQUFhLFFBQVEsSUFBSSxZQUFZLEtBQ3ZELEdBQUcsUUFBUSxJQUFJLE9BQU8sbUJBQ3RCLEdBQUcsUUFBUSxJQUFJLElBQUk7QUFFN0IsSUFBTSxpQkFBaUIsUUFBUSxLQUFLLElBQUksU0FBTyxJQUFJLE1BQU0sc0JBQXNCLENBQUMsRUFBRSxPQUFPLE9BQU8sRUFBRSxDQUFDO0FBQ25HLElBQU0sa0JBQWtCLGlCQUFpQixlQUFlLE9BQU8sUUFBUTtBQUV2RSxJQUFJLENBQUMsaUJBQWlCO0FBQ2xCLFVBQVEsTUFBTSxtSEFBbUg7QUFDakksVUFBUSxLQUFLLEVBQUU7QUFDbkI7QUFFQSxJQUFNLGVBQWUsS0FBSyxLQUFLLFlBQVksR0FBRyxlQUFlLE1BQU07QUFDbkUsSUFBTSxjQUFjLEtBQUssS0FBSyxZQUFZLEdBQUcsZUFBZSxNQUFNO0FBRWxFLElBQUksQ0FBQyxHQUFHLFdBQVcsWUFBWSxLQUFLLENBQUMsR0FBRyxXQUFXLFdBQVcsR0FBRztBQUM3RCxNQUFJLE1BQU0sY0FBYyxVQUFVLFVBQVU7QUFBQSxJQUN4QztBQUFBLElBQ0E7QUFBQSxJQUNBO0FBQUEsSUFDQTtBQUFBLElBQ0E7QUFBQSxJQUNBO0FBQUEsSUFDQTtBQUFBLEVBQ0osR0FBRyxFQUFFLE9BQU8sVUFBVyxDQUFDLEVBQUUsUUFBUTtBQUM5QixVQUFNLElBQUksTUFBTSwrQkFBK0I7QUFBQSxFQUNuRDtBQUNKO0FBR0EsSUFBTyxzQkFBUSxhQUFhO0FBQUEsRUFDeEIsU0FBUyxDQUFDLE9BQU8sQ0FBQztBQUFBLEVBQ2xCLFNBQVM7QUFBQSxJQUNMLE9BQU87QUFBQSxNQUNILEtBQUssY0FBYyxJQUFJLElBQUksU0FBUyx3Q0FBZSxDQUFDO0FBQUEsSUFDeEQ7QUFBQSxFQUNKO0FBQUEsRUFDQSxRQUFRO0FBQUEsSUFDSixPQUFPO0FBQUEsTUFDSCxxQkFBcUI7QUFBQSxRQUNqQixRQUFRO0FBQUEsUUFDUixRQUFRO0FBQUEsTUFDWjtBQUFBLElBQ0o7QUFBQSxJQUNBLE1BQU07QUFBQSxJQUNOLE9BQU87QUFBQSxNQUNILEtBQUssR0FBRyxhQUFhLFdBQVc7QUFBQSxNQUNoQyxNQUFNLEdBQUcsYUFBYSxZQUFZO0FBQUEsSUFDdEM7QUFBQSxFQUNKO0FBQ0osQ0FBQzsiLAogICJuYW1lcyI6IFtdCn0K
