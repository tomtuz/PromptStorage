## .NET 8 API for storing prompts

**API used for the 'ai-client' repo:**

- [ai-client](https://github.com/tomtuz/ai-client)


**Running (4 options):**

```sh
# 1. Manual
dotnet watch run --project src/PromptStorage

# 2. Shell script (run.sh)
chmod +x run.sh # (linux/macos only)
./run.sh
# Windows can run .sh with 'Git Bash'

# 3. 'make' utility command (to run Makefile)
make
# You can get 'make' for Windows from
# - 'chocolatey' package manager => `choco install make`
# - 'Make for Windows' from 'gnuwin32'

# 4. Docker
docker-compose build
docker-compose up
```
