# Publishing This Wiki

These files are normal Markdown pages prepared for a GitHub wiki.

GitHub stores repository wikis in a separate git repository. For this project, the wiki repository URL should be:

```text
https://github.com/Youmayu/bbs-fw-2.0.wiki.git
```

## Manual Publishing

1. Open the GitHub repository page.
2. Enable the wiki feature in repository settings if it is not already enabled.
3. Open the repository wiki.
4. Create matching pages using the files in this local `wiki/` folder.

## Git Publishing

If the wiki repository is enabled, you can also publish by cloning the wiki repository and copying these Markdown files into it.

Example:

```powershell
git clone https://github.com/Youmayu/bbs-fw-2.0.wiki.git bbs-fw-2.0.wiki
copy wiki\*.md bbs-fw-2.0.wiki\
cd bbs-fw-2.0.wiki
git add .
git commit -m "Add project wiki"
git push
```

Use this only after reviewing the pages. The local `wiki/` folder in this repository is the draft source.
