# Newbie-Games

### Cloning repository and adding origin

To clone repo please first open terminal in a directory that you want to put it in and then run:

```
git clone git@github.com:Nexxtgaming/Newbie-Games.git
```

Once this is done you will have a copy of the entire project history tree on your machine.

Now you need to add a remote server so you will be able to publish your changes.

Main server is usually named `origin`.

To add it please run

```
git remote add origin git@github.com:Nexxtgaming/Newbie-Games.git
```
## Workflow

If you want to start working on something, create a feature branch from dev

```
git checkout dev
git branch your-branch-name
git checkout your-branch-name
```

Next publish your branch to the server:

```
git push origin your-branch-name
```

Now make changes in the code and commit them to your branch. Remember to make commits regularly,
write descriptive commit messages and push your commits to the server often. This will help other people in keeping track
of your work.

To add all changed files to commit you run
```
git add -A
```
To commit your changes you run:
```
git commit -m "message" 
```

To publish your changes you run:

```
git push origin your-branch-name
```

Once you are done please create a pull request to branch dev and request a review.

Once code is ok, pull request will be merged to dev.

Do not commit directly to main and try to not commit directly to dev.

DO NOT EVER RUN PUSH WITH --force FLAG. THIS WILL REWRITE HISTORY AND CAUSE PROBLEMS FOR OTHER DEVELOPERS.
